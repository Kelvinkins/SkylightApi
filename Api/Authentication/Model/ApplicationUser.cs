using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.Model
{
    public class ApplicationUser:IdentityUser<string>
    {
        public int? SolID { get; set; }
        public string State { get; set; }

    }
}
