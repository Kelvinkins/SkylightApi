using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data
{
    public class License
    {
        private static DateTime BeginDate = new DateTime(2020, 08, 17);
        private static DateTime ExpiryDate = new DateTime(2021, 11, 30);
        public static LicenseMessage CheckLicense()
        {
            LicenseMessage Result = LicenseMessage.RUNNING;
            if (Glob.SkylightDateTime() >= ExpiryDate)
            {
                Result = LicenseMessage.LICENSE_EXPIRED;

            }
            else if (BeginDate > Glob.SkylightDateTime())
            {
                Result = LicenseMessage.SYSTEM_TIME_INCORRECT;
            }
            return Result;
        }
    }
}
