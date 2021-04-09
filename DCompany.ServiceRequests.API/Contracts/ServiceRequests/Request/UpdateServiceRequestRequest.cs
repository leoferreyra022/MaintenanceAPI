namespace DCompany.ServiceRequests.API.Contracts.ServiceRequests.Request
{
    public class UpdateServiceRequestRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
