using DCompany.ServiceRequests.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCompany.ServiceRequests.API.Services
{
    public interface IServiceRequestService
    {
        Task<List<ServiceRequestModel>> GetAllAsync();
        Task<ServiceRequestModel> GetByIdAsync(Guid id);
        Task<bool> AddAsync(ServiceRequestModel post);
        Task<bool> UpdateAsync(ServiceRequestModel post);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
