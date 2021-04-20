using Api.Authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.DataContext
{
    public class IdentityContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
        public DbSet<AuditTrail> AuditTrails { get; set; }


    }


}
