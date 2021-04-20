using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skylight.Data.Models
{
    public class ServiceResponse
    {
        public int ServiceResponseID { get; set; }
        public string ServiceID { get; set; }
        public string Log { get; set; }
        public DateTime LastRun { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
