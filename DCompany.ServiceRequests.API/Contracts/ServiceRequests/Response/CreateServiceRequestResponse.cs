using DCompany.ServiceRequests.Models;

namespace DCompany.ServiceRequests.API.Contracts.ServiceRequests.Response
{
    public class CreateServiceRequestResponse
    {
        public ServiceRequestModel ServiceRequestCreated { get; set; }
        public string CustomMessage { get; set; }
    }
}
