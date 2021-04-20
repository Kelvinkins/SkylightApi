using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models
{

    public class Company
    {
        [Display(Name = "Client ProviderLevelID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }
        [Display(Name = "Client Name")]
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        // [Index (IsUnique = true)]
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued { get; set; }
        public DateTime DueDate { get; set; }
        public int? MaximumLives { get; set; }
        public decimal? AmountPerLive { get; set; }
        public bool AllowInclusion { get; set; }
        public bool Started { get; set; }
        public string ContactPerson { get; set; }
        public string MainPassword { get; set; }
        public string EnrollmentPassword { get; set; }
        public string EnrollmentUserName { get; set; }
        // [Index (IsUnique = true)]
        public string PhoneNumber { get; set; }
        public List<Capitation> Capitations { get; set; }

        public List<CompanyPolicy> CompanyPolicies { get; set; }
        public DateTime? SystemDateTime { get; set; }

        public string MarketerID { get; set; }
        public Marketer Marketer { get; set; }
    }
}