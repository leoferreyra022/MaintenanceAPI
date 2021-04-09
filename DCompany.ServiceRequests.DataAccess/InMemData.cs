using DCompany.ServiceRequests.Models;
using System;
using System.Collections.Generic;
using static DCompany.ServiceRequests.Models.Enums.ServiceRequestStatusEnums;

namespace DCompany.ServiceRequests.DataAccess
{
    public static class InMemData
    {
        public static readonly List<ServiceRequestModel> ServiceRequests = new List<ServiceRequestModel> {
            new ServiceRequestModel
            {
                Id = Guid.NewGuid(),
                BuildingCode = "COH",
                Description = "Please turn up the AC in suite 1200D.",
                CurrentStatus = CurrentStatusEnum.Created.ToString(),
                CreatedBy = "Nik Patel",
                CreatedDate = DateTime.Parse("2019-08-01T14:25:43.511Z"),
                LastModifiedBy = "Jane Doe",
                LastModifiedDate = DateTime.Parse("2019-08-01T15:01:23.511Z")
            },
            new ServiceRequestModel
            {
                Id = Guid.NewGuid(),
                BuildingCode = "DXC",
                Description = "Please turn up the AC in suite 1200D.",
                CurrentStatus = CurrentStatusEnum.Canceled.ToString(),
                CreatedBy = "Nick Blue",
                CreatedDate = DateTime.Parse("2019-08-04T14:25:43.511Z"),
                LastModifiedBy = "Matt Cox",
                LastModifiedDate = DateTime.Parse("2019-08-04T15:01:23.511Z")
            },
            new ServiceRequestModel
            {
                Id = Guid.NewGuid(),
                BuildingCode = "XAS",
                Description = "Please turn up the AC in suite 1200D.",
                CurrentStatus = CurrentStatusEnum.Complete.ToString(),
                CreatedBy = "Ali Stout",
                CreatedDate = DateTime.Parse("2019-10-01T14:25:43.511Z"),
                LastModifiedBy = "Amber Ale",
                LastModifiedDate = DateTime.Parse("2019-10-01T15:01:23.511Z")
            },
            new ServiceRequestModel
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ASD",
                Description = "Please turn up the AC in suite 1200D.",
                CurrentStatus = CurrentStatusEnum.InProgress.ToString(),
                CreatedBy = "Jhon Pilsener",
                CreatedDate = DateTime.Parse("2019-04-01T14:25:43.511Z"),
                LastModifiedBy = "Mr Pink",
                LastModifiedDate = DateTime.Parse("2019-05-01T15:01:23.511Z")
            },
            new ServiceRequestModel
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ROB",
                Description = "Please turn up the AC in suite 1200D.",
                CurrentStatus = CurrentStatusEnum.NotApplicable.ToString(),
                CreatedBy = "Arnold Zoom",
                CreatedDate = DateTime.Parse("2020-08-01T14:25:43.511Z"),
                LastModifiedBy = "Mr Robot",
                LastModifiedDate = DateTime.Parse("2020-08-01T15:01:23.511Z")
            }
        };
    }
}
