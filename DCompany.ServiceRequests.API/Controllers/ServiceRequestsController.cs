using DCompany.ServiceRequests.API.Contracts.ServiceRequests.Request;
using DCompany.ServiceRequests.API.Contracts.ServiceRequests.Response;
using DCompany.ServiceRequests.API.Services;
using DCompany.ServiceRequests.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static DCompany.ServiceRequests.Models.Enums.ServiceRequestStatusEnums;

namespace DCompany.ServiceRequests.API.Controllers
{
    [ApiController]
    [Route("api/servicerequest")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestsController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _serviceRequestService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var resultList = await _serviceRequestService.GetAllAsync();

            if (resultList == null)
            {
                return NoContent();
            }

            return Ok(resultList);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(
            [FromBody] CreateServiceRequestRequest createServiceRequestRequest)
        {
            if (createServiceRequestRequest == null || createServiceRequestRequest.Code == null)
            {
                return BadRequest();
            }

            var user = "SwaggerUser";
            var serviceRequest = new ServiceRequestModel
            {
                Id = Guid.NewGuid(),
                BuildingCode = createServiceRequestRequest.Code,
                CreatedBy = user,
                CreatedDate = DateTime.Now,
                CurrentStatus = CurrentStatusEnum.Created.ToString(),
                Description = createServiceRequestRequest.Description,
                LastModifiedBy = user,
                LastModifiedDate = DateTime.Now
            };

            var added = await _serviceRequestService.AddAsync(serviceRequest);

            if (!added)
            {
                return NoContent();
            }

            var response = new CreateServiceRequestResponse
            {
                ServiceRequestCreated = serviceRequest,
                CustomMessage = "Congrats! You added a new Service Request!"
            };

            return Ok(response);
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateServiceRequestRequest updateServiceRequestRequest)
        {
            if (id == null || updateServiceRequestRequest == null)
                return BadRequest();

            if (!Enum.TryParse<CurrentStatusEnum>(updateServiceRequestRequest.Status, out var _))
                return BadRequest();

            var user = "SwaggerUser";
            var serviceRequest = new ServiceRequestModel
            {
                Id = id,
                BuildingCode = updateServiceRequestRequest.Code,
                CurrentStatus = updateServiceRequestRequest.Status,
                Description = updateServiceRequestRequest.Description,
                LastModifiedBy = user,
                LastModifiedDate = DateTime.Now
            };

            if (await _serviceRequestService.UpdateAsync(serviceRequest))
                return Ok(serviceRequest);

            return NotFound();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _serviceRequestService.DeleteByIdAsync(id);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
