using DCompany.ServiceRequests.DataAccess;
using DCompany.ServiceRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCompany.ServiceRequests.API.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IDataContext _dataContext;
        public ServiceRequestService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ServiceRequestService() : this(new DataContext())
        {
        }
        public async Task<bool> AddAsync(ServiceRequestModel serviceRequestModel)
        {
            try
            {
                await Task.Run(() => { _dataContext.ServiceRequests.Add(serviceRequestModel); });

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            try
            {
                var serviceRequest = await GetByIdAsync(id);

                if (serviceRequest == null)
                    return false;

                await Task.Run(() => { _dataContext.ServiceRequests.RemoveAll(x => x.Id == id); });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ServiceRequestModel>> GetAllAsync()
        {
            try
            {
                var serviceRequestsList = await Task.Run(() => { return _dataContext.ServiceRequests; });

                return serviceRequestsList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ServiceRequestModel> GetByIdAsync(Guid id)
        {
            try
            {
                var serviceRequest = await Task.Run(() =>
                {
                    return _dataContext.ServiceRequests.SingleOrDefault(x => x.Id == id);
                });

                return serviceRequest;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(ServiceRequestModel serviceRequest)
        {
            try
            {
                if (serviceRequest.Id == null)
                    return false;

                var serviceRequestResponse = await GetByIdAsync(serviceRequest.Id);

                if (serviceRequestResponse == null)
                    return false;

                if (serviceRequest.Equals(serviceRequestResponse))
                    return false;

                //TODO: Move logic to a ServiceRequestManager
                var index = _dataContext.ServiceRequests.IndexOf(serviceRequestResponse);
                await DeleteByIdAsync(serviceRequest.Id);

                serviceRequest.CreatedBy = serviceRequestResponse.CreatedBy;
                serviceRequest.CreatedDate = serviceRequestResponse.CreatedDate;

                _dataContext.ServiceRequests.Insert(index, serviceRequest);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
