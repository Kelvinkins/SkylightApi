using Skylight.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models {

    public class TariffDetail {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int TariffDetailID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued { get; set; }

        public string TariffID { get; set; }
        public Tariff Tariff { get; set; }

        public int? ClassificationID { get; set; }
        public Classification Classification { get; set; }
    }
}