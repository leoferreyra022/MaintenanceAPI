using DCompany.ServiceRequests.Models;
using System.Collections.Generic;

namespace DCompany.ServiceRequests.DataAccess
{
    public interface IDataContext
    {
        List<ServiceRequestModel> ServiceRequests { get; }
    }
}