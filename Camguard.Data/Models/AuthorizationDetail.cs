using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {
    public class AuthorizationDetail {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int AuthorizationDetailID { get; set; }
        public DateTime SystemDate { get; set; }
        public int AuthorizationID { get; set; }
        public Authorization Authorization { get; set; }
        public MUnite Unit { get; set; } //e.g Tablets,Syrup
        public MPeriod Period { get; set; } //e.g Daily,Weekly
        public int? DosageQuantity { get; set; } //e.g 2 tablets in the morning two in the evening
        public int Duration { get; set; } //How long the drug was given. e.g for one month
        public int Quantity { get; set; } //TotalDosageQuanity x Period x Duration
        public decimal UnitPrice { get; set; } //Price of each drug/service
        public decimal Total { get; set; } //UnitPrice x Quantity
        public bool Rejected { get; set; }
        public int TariffDetailID { get; set; } //DrugID/ServiceID
        public TariffDetail TariffDetail { get; set; } //Drug/Service 
        public int? AuthorizationDiagnoID { get; set; } //DrugID/ServiceID
        public AuthorizationDiagno AuthorizationDiagno { get; set; } //Drug/Service 

    }
}