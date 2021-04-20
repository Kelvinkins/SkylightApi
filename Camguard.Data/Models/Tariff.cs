using Skylight.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models {

    public class Tariff {
        public string TariffID { get; set; }
        public string TariffName { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued { get; set; }
        public List<Provider> Providers { get; set; }
        public List<TariffDetail> TariffDetails { get; set; }
        public List<Classification> Classifications { get; set; }


    }
}