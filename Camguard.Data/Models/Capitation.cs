using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class Capitation {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int CapitationID { get; set; }
        public string EmployeeID { get; set; }
        public string EnrolleeCode { get; set; }

        public string Surname { get; set; }
        public string OtherName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string StaffID { get; set; }
        public EnrType EnrolleeType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Sex? Gender { get; set; }
        public SerType ServiceType { get; set; }
        public DateTime MainDate { get; set; }
        public DateTime SystemDate { get; set; }
        public int ProviderID { get; set; }
        public Provider Provider { get; set; }
        public decimal Amount { get; set; }
        public String PolicyID { get; set; }
        public Plan Policy { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int CapitationMasterID { get; set; }
        public CapitationMaster CapitationMaster { get; set; }

        public bool? Sent { get; set; }
        public DateTime? DateSent { get; set; }


    }
}