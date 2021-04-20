using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data.Models
{
    public class EmailAccount
    {
        public Module ID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime SystemDateTime { get; set; }

    }
}
