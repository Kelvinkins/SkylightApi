using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Skylight.Data.Models;
using Skylight.Models.Enums;

namespace Skylight.Models {

    public class Employee: BaseModel
    {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public string OldID { get; set; }
        public string Surname { get; set; }
        public string OtherName { get; set; }
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
        public GenType Genotype { get; set; }

        public DateTime? StartDate { get; set; }
        public bool Started { get; set; }

        public List<Dependant> Dependants { get; set; }

        public int ProviderID { get; set; }
        public Provider Provider { get; set; }

        public String PolicyID { get; set; }
        public Plan Policy { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public bool IDCardPrinted { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }

        public String StateID { get; set; }
        public State State { get; set; }
        public String RegionID { get; set; }
        public Region Region { get; set; }
        public DateTime SystemDateTime { get; set; }
        public DateTime LastUpdated { get; set; }


    }
}