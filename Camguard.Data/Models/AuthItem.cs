using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class AuthItem {
        public string AuthItemID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public List<Authorization> Authorizations { get; set; }
    }
}