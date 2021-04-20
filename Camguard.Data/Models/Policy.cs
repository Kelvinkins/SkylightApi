using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Skylight.Models {

    public class Policy {
        public string PolicyID { get; set; }
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal Amount{get;set;}
        public bool Discontinued { get; set; }
        public List<Employee> Employee { get; set; }
        public List<Dependant> Dependants { get; set; }
        public List<CompanyPolicy> CompanyPolicies { get; set; }
        public List<Capitation> Capitations { get; set; }
        public List<BenefitCover> BenefitCovers { get; set; }

        public int? ProviderLevelID { get; set; }
        public ProviderLevel ProviderLevel { get; set; }
        public bool AllowDependant { get; set; }
    }
}