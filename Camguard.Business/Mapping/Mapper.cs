using Camguard.Business.IContract;
using Skylight.Data.ViewModel;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Mapping
{
    public class Mapper:IMapper
    {
        public Employee EmployeeFromViewModel(EmployeeViewModel viewModel)
        {
            Employee employee = new Employee()
            {
                Surname = viewModel.Surname,
                OtherName = viewModel.OtherName,
                Address = viewModel.Address,
                Address2 = viewModel.Address2,
                City = viewModel.City,
                CompanyID = viewModel.CompanyID,
                DateOfBirth = viewModel.DateOfBirth,
                Discontinued = viewModel.Discontinued,
                Email = viewModel.Email,
                Gender = viewModel.Gender,
                Genotype = viewModel.Genotype,
                IDCardPrinted = viewModel.IDCardPrinted,
                LastUpdated = viewModel.LastUpdated,
                MaritalStatus = viewModel.MaritalStatus,
                OldID = viewModel.OldID,
                PhoneNumber = viewModel.PhoneNumber,
                PhotoUrl = viewModel.PhotoUrl,
                PolicyID = viewModel.PolicyID,
                ProviderID = viewModel.ProviderID,
                RegionID = viewModel.RegionID,
                StateID = viewModel.StateID,
                RegistrationDate = viewModel.RegistrationDate,
                StartDate = viewModel.StartDate,
                Started = viewModel.Started,
                StaffID = viewModel.StaffID,
                SystemDateTime = viewModel.SystemDateTime

            };
            return employee;
        }
        public Dependant DependantFromViewModel(DependantViewModel viewModel)
        {
            Dependant employee = new Dependant()
            {
                Surname = viewModel.Surname,
                OtherName = viewModel.OtherName,
                Address = viewModel.Address,
                CompanyID = viewModel.CompanyID,
                DateOfBirth = viewModel.DateOfBirth,
                Discontinued = viewModel.Discontinued,
                Email = viewModel.Email,
                Gender = viewModel.Gender,
                Genotype = viewModel.Genotype,
                IDCardPrinted = viewModel.IDCardPrinted,
                LastUpdated = viewModel.LastUpdated,
                OldID = viewModel.OldID,
                PhoneNumber = viewModel.PhoneNumber,
                PhotoUrl = viewModel.PhotoUrl,
                PolicyID = viewModel.PolicyID,
                ProviderID = viewModel.ProviderID,
                StateID = viewModel.StateID,
                RegistrationDate = viewModel.RegistrationDate,
                StartDate = viewModel.StartDate,
                Started = viewModel.Started,
                StaffID = viewModel.StaffID,
                SystemDateTime = viewModel.SystemDateTime,
                Letter = viewModel.Letter,
                Relationship = viewModel.Relationship,
                DependantType = viewModel.DependantType
            };
            return employee;
        }
    }
}
