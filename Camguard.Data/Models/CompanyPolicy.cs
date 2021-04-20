using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Skylight.Models {
   
    public class CompanyPolicy {
        public string CompanyPolicyID { get; set; }
        public string CompanyPolicyName { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued{get;set;}
        public string PolicyID{get;set;}
        public Policy Policy{get;set;}

         public int CompanyID { get; set; }
        public Company Company{get;set;}

    }
}