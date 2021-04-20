using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models {

    public class ClaimsBatch {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ClaimsBatchID { get; set; }
        public string ClaimsBatchCode{get;set;}
        public string Remark { get; set; }
        public DateTime DateRecived { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public List<Claim> Claims { get; set; }
        public int ClosingCount{get;set;}
        public bool? Closed{get;set;}//marks to show the provider has submitted 
        public DateTime OpenDate {get;set;} //marks to show all claims in this batch has bee processed
        public DateTime CloseDate { get; set; }
    }
}