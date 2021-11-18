using Skylight.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Skylight.Models {
   
    public class CompanyPolicy :BaseModel
    {
        public string CompanyPolicyID { get; set; }
        public string CompanyPolicyName { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued{get;set;}
        public string PolicyID{get;set;}
        public Plan Policy{get;set;}

         public int CompanyID { get; set; }
        public Company Company{get;set;}
        public DateTime? SystemDateTime { get; set; }

    }
}