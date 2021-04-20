using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class Log {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }
        public Module SystemModule { get; set; }
        public LogActivity LogType{get;set;}
        public string Description { get; set; }
        public DateTime LogDate { get; set; }
        public bool CanClear{get;set;}
         public string UserName { get; set; }
        public string EntityID { get; set; }

    }
}