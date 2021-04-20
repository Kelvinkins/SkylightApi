using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {
    public class ClaimDetail {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ClaimDetailID { get; set; }
        public string Name { get; set; }
        public DateTime SystemDate { get; set; }
        public int ClaimID { get; set; }
        public Claim Claim { get; set; }
        public MUnite Unit { get; set; } //e.g Tablets,Syrup
        [Display(Name = "Freq", Order = -9,   
        Prompt = "Enter Frequency", Description="Frequency")]  
        public MPeriod Period { get; set; } //e.g Daily,Weekly
         [Display(Name = "D.qty", Order = -9,   
        Prompt = "Enter Dosage Quantity", Description="Dosage Quantity")]
        public int? DosageQuantity { get; set; } //e.g 2 tablets in the morning two in the evening
        public int Duration { get; set; } //How long the drug was given. e.g for one month
        public int Quantity { get; set; } //TotalDosageQuanity x Period x Duration
        public decimal UnitPrice { get; set; } //Price of each drug/service
        public decimal Total { get; set; } //UnitPrice x Quantity
        public bool Rejected { get; set; }
        public int TariffDetailID { get; set; } //DrugID/ServiceID
        public TariffDetail TariffDetail { get; set; } //Drug/Service 
        public int? ClaimDiagnoID { get; set; } //DrugID/ServiceID
        public ClaimDiagno ClaimDiagno { get; set; } //Drug/Service 

    }
}