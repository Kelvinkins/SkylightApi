using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.Model
{
    public class AuditTrail
    {
        public int AuditTrailID { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string IpAddress { get; set; }

    }
}
