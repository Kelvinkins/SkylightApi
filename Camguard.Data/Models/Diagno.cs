using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class Diagno {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int DiagnoID { get; set; }
        public string Name { get; set; }     
        public string Code { get; set; }
        public string Description{get;set;}
        public DateTime SystemDate { get; set; }
    }
}