using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models {

    public class CapitationMaster {
        public int CapitationMasterID { get; set; }
        public string CapitationMasterName { get; set; }
        public string Narration { get; set; }
        public DateTime DueDate { get; set; }
        public string AdditionalAmount {get;set;}
        public DateTime? SystemDateTime { get; set; }
        public List<Capitation> Capitations { get; set; }
        public bool? Published { get; set; }
        public DateTime? DatePublished { get; set; }
        public bool? Finished { get; set; }




    }
}