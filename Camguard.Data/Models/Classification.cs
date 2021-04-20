using Skylight.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data.Models
{
    public class Classification
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassificationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TariffID { get; set; }
        public Tariff Tariff { get; set; }
        public List<TariffDetail> TariffDetails { get; set; }


    }
}
