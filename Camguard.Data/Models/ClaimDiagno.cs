using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class ClaimDiagno {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ClaimDiagnoID { get; set; }
        public DateTime SystemDate { get; set; }
        public int DiagnoID { get; set; } //DrugID/ServiceID
        public Diagno Diagno { get; set; } //Drug/Service 
        public DiagType DiagnoType { get; set; }
        public int ClaimID { get; set; } //DrugID/ServiceID
        public Claim Claim { get; set; } //D
    }
}