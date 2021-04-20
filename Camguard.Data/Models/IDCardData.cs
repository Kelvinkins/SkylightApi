using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data.Models
{
    public class IDCardData
    {

        public string EnrolleeID { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Sex? Gender { get; set; }
        public MaritalStat MaritalStatus { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool Discontinued { get; set; }
        public string PhotoUrl { get; set; }
        public string StaffID { get; set; }
        // [Index(IsUnique=true)]
        public string PhoneNumber { get; set; }
        //  [Index(IsUnique=true)]
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? StartDate { get; set; }
        public bool Started { get; set; }


        public string ProviderName { get; set; }
        public EnrType EnrolleeType { get; set; }
        public String Plan { get; set; }

        public string CompanyName { get; set; }
        public string EnrolleCode { get; set; }

    }
    
}

