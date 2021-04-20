using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {
    public class AuthorizationDiagno {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int AuthorizationDiagnoID { get; set; }
        public DateTime SystemDate { get; set; }
        public int DiagnoID { get; set; } //DrugID/ServiceID
        public Diagno Diagno { get; set; } //Drug/Service 
        public DiagType DiagnoType { get; set; }
        public int AuthorizationID { get; set; } //DrugID/ServiceID
        public Authorization Authorization { get; set; } //D
    }
}