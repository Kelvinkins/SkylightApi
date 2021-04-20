using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data.Models
{
    public class BenefitCategory
    {
        public int BenefitCategoryID { get; set; }
        public string Name { get; set; }
        public DateTime SystemDateTime { get; set; }
        public List<BenefitCover> BenefitCovers { get; set; }
    }
}
