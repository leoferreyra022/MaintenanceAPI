using DCompany.ServiceRequests.Models;
using System.Collections.Generic;

namespace DCompany.ServiceRequests.DataAccess
{
    public class DataContext : IDataContext
    {
        private readonly List<ServiceRequestModel> ServiceRequests = InMemData.ServiceRequests;

        List<ServiceRequestModel> IDataContext.ServiceRequests => ServiceRequests;
    }
}
