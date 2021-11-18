using Skylight.Data.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skylight.Models {

    public class BenefitCover {
     [DatabaseGenerated (DatabaseGeneratedOption.Identity)]

        public int BenefitCoverID { get; set; }
        public string Benefit { get; set; }
        public DateTime SystemDate { get; set; }
        public bool Discontinued { get; set; }
        public bool? GenderBound { get; set; }
        public string PolicyID { get; set; }
        public RuleLimitType? Limit { get; set; } = RuleLimitType.NoLimit;
        public string LimitValue { get; set; }
        public Plan Policy { get; set; }

        public int? BenefitCategoryID { get; set; }
        public BenefitCategory BenefitCategory { get; set; }
    }
}