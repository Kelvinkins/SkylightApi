using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class Authorization {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]

        public int AuthorizationID { get; set; }
        public string EmployeeID { get; set; }
        public EnrType EnrolleeType { get; set; }
        public int ProviderID { get; set; }
        public Provider Provider { get; set; }

        public string Remark { get; set; }
        public string ProviderRemark { get; set; }
        public string Code { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public DateTime? DateAccepted{get;set;}

        public ReqStatus Status { get; set; }
        public List<AuthorizationDetail> AuthorizationDetails { get; set; }
        // public bool? Processed { get; set; } //marks to show that this Authorizations has been processed
        public int? ClaimID { get; set; }
        public Claim Claim { get; set; }

        public string AuthItemID { get; set; }
        public AuthItem AuthItem { get; set; }
    }
}