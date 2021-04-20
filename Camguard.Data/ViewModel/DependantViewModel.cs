using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data.ViewModel
{
    public class DependantViewModel
    {
        public string ID { get; set; }
        public string Surname { get; set; }
        public string OtherName { get; set; }
        public string OldID { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool Discontinued { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Sex Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string StaffID { get; set; }
        public RelType Relationship { get; set; }
        public DepType DependantType { get; set; }
        public int EmployeeID { get; set; }
        public string Address { get; set; }
        public DateTime? StartDate { get; set; }
        public bool Started { get; set; }
        public GenType Genotype { get; set; }
        public int? ProviderID { get; set; }
        public string PolicyID { get; set; }
        public bool IDCardPrinted { get; set; }
        public string StateID { get; set; }
        public string Region { get; set; }
        public string Letter { get; set; }
        public DateTime SystemDateTime { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? CompanyID { get; set; }
    }
}
