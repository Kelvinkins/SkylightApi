using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models {

    public class EmailSetting {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool Discontinued { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public bool Ssl { get; set; }
    }

    public class SmsSetting {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Gateway { get; set; }
        public string Password { get; set; }
        public int DisplayName { get; set; }
        public bool Discontinued { get; set; }
        public DateTime? SystemDateTime { get; set; }
    }

    public class GeneralSetting {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }

        public string BusinessAddress { get; set; }
        public string CapitationEmail { get; set; }
        public string ClaimsEmail { get; set; }
        public string GeneralEmail { get; set; }

    }
}