using DCompany.ServiceRequests.API.Services;
using DCompany.ServiceRequests.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCompany.ServiceRequests.API.Controllers.Tests
{
    [TestClass()]
    public class ServiceRequestsControllerTests
    {
        private readonly Mock<IServiceRequestService> _serviceRequestServiceMock;
        private readonly List<ServiceRequestModel> _serviceRequestModels;

        public ServiceRequestsControllerTests()
        {
            _serviceRequestServiceMock = new Mock<IServiceRequestService>();
            _serviceRequestModels = new List<ServiceRequestModel>
            {
                new ServiceRequestModel { Id = Guid.NewGuid(), BuildingCode = "A", CreatedBy = "me"},
                new ServiceRequestModel { Id = Guid.NewGuid(), BuildingCode = "B", CreatedBy = "me"},
                new ServiceRequestModel { Id = Guid.NewGuid(), BuildingCode = "C", CreatedBy = "me"},
                new ServiceRequestModel { Id = Guid.NewGuid(), BuildingCode = "D", CreatedBy = "me"},
            };
        }

        [TestMethod()]
        public async Task ServiceRequest_Get_Should_Work()
        {
            var newGuid = Guid.NewGuid();
            var expectedServiceRequest = _serviceRequestModels.First();

            _serviceRequestServiceMock
                .Setup(x => x.GetByIdAsync(newGuid).Result)
                .Returns(expectedServiceRequest);

            var controller = new ServiceRequestsController(_serviceRequestServiceMock.Object);
            var getResult = await controller.Get(newGuid);

            getResult.Should().NotBeNull();

            var okResult = getResult as OkObjectResult;

            okResult.Value.Should().BeEquivalentTo(expectedServiceRequest);
        }
    }
}