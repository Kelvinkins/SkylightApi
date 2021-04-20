using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models
{

    public class Rule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RuleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public RuleType RulesType { get; set; }//General or Clinical Rule
        public RuleLimitType RulesLimitType { get; set; } //Limit unit of the rule
        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public bool? Activated { get; set; }
    }
}