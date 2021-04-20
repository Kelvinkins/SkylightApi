using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skylight.Data.Models;
using Skylight.Models;
namespace Skylight.Data
{
    public class SkyDbContext :DbContext
    {
        public SkyDbContext(DbContextOptions<SkyDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPolicy> CompanyPolicies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependant> Dependants { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ProviderLevel> ProviderLevels { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }
        public DbSet<SmsSetting> SmsSettings { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffDetail> TariffDetails { get; set; }
        public DbSet<CapitationMaster> CapitationMasters { get; set; }
        public DbSet<Capitation> Capitations { get; set; }
        public DbSet<Marketer> Marketers { get; set; }
        public DbSet<BenefitCover> BenefitCovers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimDetail> ClaimDetails { get; set; }
        public DbSet<ClaimsBatch> ClaimsBatches { get; set; }
        public DbSet<Diagno> Diagnos { get; set; }
        public DbSet<ClaimDiagno> ClaimDiagnos { get; set; }
        public DbSet<AuthorizationDiagno> AuthorizationDiagnos { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<AuthorizationDetail> AuthorizationDetails { get; set; }
        public DbSet<AuthItem> AuthItems { get; set; }
        public DbSet<Rule> Rules{get;set;}
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<EmailAccount> EmailAccounts { get; set; }
        public DbSet<BenefitCategory> BenefitCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ServiceResponse> ServiceResponses { get; set; }


    }

}
