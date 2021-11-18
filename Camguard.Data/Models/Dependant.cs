using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Data.Models;
using Skylight.Models.Enums;

namespace Skylight.Models {

    public class Dependant {
        public string DependantID { get; set; }
        public string Surname { get; set; }
        public string OtherName { get; set; }
        public string OldID { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool Discontinued { get; set; }

        // [Index (IsUnique = true)]

        //[StringLength(11,ErrorMessage ="", null, null, 11)]
        [DataType(DataType.PhoneNumber,ErrorMessage = "Invalid Phone number")]
        public string PhoneNumber { get; set; }

        // [Index (IsUnique = true)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }
        public Sex Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string StaffID { get; set; }
        public RelType Relationship { get; set; }
        // public bool IsSpecial { get; set; }
        public DepType DependantType { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public string Address { get; set; }
        public DateTime? StartDate { get; set; }
        public bool Started { get; set; }

        public GenType Genotype { get; set; }

        public int? ProviderID { get; set; }
        public Provider Provider { get; set; }

        public String PolicyID { get; set; }
        public Plan Policy { get; set; }
        public bool IDCardPrinted { get; set; }

        public String StateID { get; set; }
        public string Region { get; set; }
        public State State { get; set; }
        public string Letter { get; set; }
        public DateTime SystemDateTime { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? CompanyID { get; set; }



    }
}