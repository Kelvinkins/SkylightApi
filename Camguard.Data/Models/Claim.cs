using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 using Skylight.Models.Enums;
 namespace Skylight.Models {

    public class Claim {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]

        public int ClaimID { get; set; }
        public string EmployeeID { get; set; }
        public ClaimsBatch ClaimsBatch { get; set; }
        public int? ClaimsBatchID { get; set; }
        public int ProviderID { get; set; }
        public Provider Provider { get; set; }
        public string Remark { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public List<ClaimDetail> ClaimDetails { get; set; }
        public List<Authorization> Authorizations { get; set; }
        public bool? Submitted { get; set; } //marks to show that this claims has been submitted by the provider

        public DateTime? DateProcessed { get; set; }
        public ProcessSource Source { get; set; } // marks the source of the claims
        public bool Processed { get; set; } //marks to show that this claims has been processed
        public bool Paid { get; set; } // marks to show that the claims has been paid

    }
}