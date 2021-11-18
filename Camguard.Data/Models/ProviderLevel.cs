using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skylight.Models {

    public class ProviderLevel {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProviderLevelID { get; set; }
        public string ProviderLevelName { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued { get; set; }
        public int Level{get;set;}
        public List<Plan> Policies { get; set; }
        public List<Provider> Providers { get; set; }
    }
}