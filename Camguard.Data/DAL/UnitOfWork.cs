using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Camguard.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Skylight.Data;
using Skylight.Data.Models;
using Skylight.Models;
using Skylight.Models.Enums;

namespace Skylight.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly SkyDbContext context;
        private SkylightRepository<Company> companyRepository;
        private SkylightRepository<CompanyPolicy> companyPolicyRepository;
        private SkylightRepository<Employee> employeeRepository;
        private SkylightRepository<Dependant> dependantRepository;
        private SkylightRepository<Provider> providerRepository;
        private SkylightRepository<Capitation> capitationRepository;
        private SkylightRepository<Policy> policyRepository;
        private SkylightRepository<ProviderLevel> providerLevelRepository;

        private SkylightRepository<Log> logRepository;
        private SkylightRepository<CapitationMaster> capitationMasterRepository;
        private SkylightRepository<ClaimsBatch> claimsBatchRepository;
        private SkylightRepository<ClaimDetail> claimDetailRepository;
        private SkylightRepository<Tariff> tariffRepository;
        private SkylightRepository<TariffDetail> tariffDetailRepository;

        private SkylightRepository<Authorization> authorizationRepository;
        private SkylightRepository<AuthItem> authItemRepository;
        private SkylightRepository<AuthorizationDetail> authorizationDetailRepository;
        private SkylightRepository<Marketer> marketerRepository;
        private SkylightRepository<Classification> classificationRepository;
        private SkylightRepository<Diagno> diagnosisRepository;
        private SkylightRepository<Rule> ruleRepository;
        private SkylightRepository<EmailSetting> emailSettingsRepository;
        private SkylightRepository<Claim> claimRepository;
        public SkylightRepository<EmailAccount> emailAccountRepository;
        public SkylightRepository<BenefitCover> benefitCover;
        public SkylightRepository<BenefitCategory> benefitCategory;
        public SkylightRepository<Region> regionRepository;
        public SkylightRepository<State> stateRepository;
        public SkylightRepository<ServiceResponse> serviceResponseRepository;
        public UnitOfWork(SkyDbContext _context)
        {
            context = _context;
        }



        public SkylightRepository<ServiceResponse> ServiceResponseRepository
        {
            get
            {

                if (this.serviceResponseRepository == null)
                {
                    this.serviceResponseRepository = new SkylightRepository<ServiceResponse>(context);
                }
                return serviceResponseRepository;
            }
        }
         public SkylightRepository<BenefitCategory> BenefitCategoryRepository
        {
            get
            {

                if (this.benefitCategory == null)
                {
                    this.benefitCategory = new SkylightRepository<BenefitCategory>(context);
                }
                return benefitCategory;
            }
        }


        public SkylightRepository<Region> RegionRepository
        {
            get
            {

                if (this.regionRepository == null)
                {
                    this.regionRepository = new SkylightRepository<Region>(context);
                }
                return regionRepository;
            }
        }
        public SkylightRepository<State> StateRepository
        {
            get
            {

                if (this.stateRepository == null)
                {
                    this.stateRepository = new SkylightRepository<State>(context);
                }
                return stateRepository;
            }
        }
        public SkylightRepository<Rule> RuleRepository
        {
            get
            {

                if (this.ruleRepository == null)
                {
                    this.ruleRepository = new SkylightRepository<Rule>(context);
                }
                return ruleRepository;
            }
        }
        public SkylightRepository<BenefitCover> BenefitCoverRepository
        {
            get
            {

                if (this.benefitCover == null)
                {
                    this.benefitCover = new SkylightRepository<BenefitCover>(context);
                }
                return benefitCover;
            }
        }
        public SkylightRepository<EmailAccount> EmailAccountRepository
        {
            get
            {

                if (this.emailAccountRepository == null)
                {
                    this.emailAccountRepository = new SkylightRepository<EmailAccount>(context);
                }
                return emailAccountRepository;
            }
        }
        public SkylightRepository<EmailSetting> EmailSettingsRepository
        {
            get
            {

                if (this.emailSettingsRepository == null)
                {
                    this.emailSettingsRepository = new SkylightRepository<EmailSetting>(context);
                }
                return emailSettingsRepository;
            }
        }
        public SkylightRepository<Classification> ClassificationRepository
        {
            get
            {

                if (this.classificationRepository == null)
                {
                    this.classificationRepository = new SkylightRepository<Classification>(context);
                }
                return classificationRepository;
            }
        }

        public SkylightRepository<Diagno> DiagnosisRepository
        {
            get
            {

                if (this.diagnosisRepository == null)
                {
                    this.diagnosisRepository = new SkylightRepository<Diagno>(context);
                }
                return diagnosisRepository;
            }
        }


        public SkylightRepository<Marketer> MarketerRepository
        {
            get
            {

                if (this.marketerRepository == null)
                {
                    this.marketerRepository = new SkylightRepository<Marketer>(context);
                }
                return marketerRepository;
            }
        }
        public SkylightRepository<AuthorizationDetail> AuthorizationDetailRepository
        {
            get
            {

                if (this.authorizationDetailRepository == null)
                {
                    this.authorizationDetailRepository = new SkylightRepository<AuthorizationDetail>(context);
                }
                return authorizationDetailRepository;
            }
        }


        public SkylightRepository<Authorization> AuthorizationRepository
        {
            get
            {

                if (this.authorizationRepository == null)
                {
                    this.authorizationRepository = new SkylightRepository<Authorization>(context);
                }
                return authorizationRepository;
            }

        }

        public SkylightRepository<AuthItem> AuthItemRepository
        {
            get
            {

                if (this.authItemRepository == null)
                {
                    this.authItemRepository = new SkylightRepository<AuthItem>(context);
                }
                return authItemRepository;
            }
        }

        public SkylightRepository<Claim> ClaimRepository
        {
            get
            {

                if (this.claimRepository == null)
                {
                    this.claimRepository = new SkylightRepository<Claim>(context);
                }
                return claimRepository;
            }
        }

      

        public SkylightRepository<TariffDetail> TariffDetailRepository
        {
            get
            {

                if (this.tariffDetailRepository == null)
                {
                    this.tariffDetailRepository = new SkylightRepository<TariffDetail>(context);
                }
                return tariffDetailRepository;
            }
        }


        public SkylightRepository<Tariff> TariffRepository
        {
            get
            {

                if (this.tariffRepository == null)
                {
                    this.tariffRepository = new SkylightRepository<Tariff>(context);
                }
                return tariffRepository;
            }
        }

        public SkylightRepository<ClaimDetail> ClaimDetailRepository
        {
            get
            {

                if (this.claimDetailRepository == null)
                {
                    this.claimDetailRepository = new SkylightRepository<ClaimDetail>(context);
                }
                return claimDetailRepository;
            }
        }
        public SkylightRepository<Capitation> CapitationRepository
        {
            get
            {

                if (this.capitationRepository == null)
                {
                    this.capitationRepository = new SkylightRepository<Capitation>(context);
                }
                return capitationRepository;
            }
        }
        public SkylightRepository<ClaimsBatch> ClaimsBatchRepository
        {
            get
            {

                if (this.claimsBatchRepository == null)
                {
                    this.claimsBatchRepository = new SkylightRepository<ClaimsBatch>(context);
                }
                return claimsBatchRepository;
            }
        }

        public SkylightRepository<CapitationMaster> CapitationMasterRepository
        {
            get
            {

                if (this.capitationMasterRepository == null)
                {
                    this.capitationMasterRepository = new SkylightRepository<CapitationMaster>(context);
                }
                return capitationMasterRepository;
            }
        }
        public SkylightRepository<ProviderLevel> ProviderLevelRepository
        {
            get
            {

                if (this.providerLevelRepository == null)
                {
                    this.providerLevelRepository = new SkylightRepository<ProviderLevel>(context);
                }
                return providerLevelRepository;
            }
        }
        public SkylightRepository<Policy> PolicyRepository
        {
            get
            {

                if (this.policyRepository == null)
                {
                    this.policyRepository = new SkylightRepository<Policy>(context);
                }
                return policyRepository;
            }
        }
        public SkylightRepository<Provider> ProviderRepository
        {
            get
            {

                if (this.providerRepository == null)
                {
                    this.providerRepository = new SkylightRepository<Provider>(context);
                }
                return providerRepository;
            }
        }
        public SkylightRepository<Dependant> DependantRepository
        {
            get
            {

                if (this.dependantRepository == null)
                {
                    this.dependantRepository = new SkylightRepository<Dependant>(context);
                }
                return dependantRepository;
            }
        }

        public SkylightRepository<Employee> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new SkylightRepository<Employee>(context);
                }
                return employeeRepository;
            }
        }

        public SkylightRepository<CompanyPolicy> CompanyPolicyRepository
        {
            get
            {

                if (this.companyPolicyRepository == null)
                {
                    this.companyPolicyRepository = new SkylightRepository<CompanyPolicy>(context);
                }
                return companyPolicyRepository;
            }
        }

        public SkylightRepository<Company> CompanyRepository
        {
            get
            {

                if (this.companyRepository == null)
                {
                    this.companyRepository = new SkylightRepository<Company>(context);
                }
                return companyRepository;
            }
        }

        public SkylightRepository<Log> LogRepository
        {
            get
            {

                if (this.logRepository == null)
                {
                    this.logRepository = new SkylightRepository<Log>(context);
                }
                return logRepository;
            }
        }

        public async Task<int> ClearEntity(string TableName, bool trucate = false)
        {
            if (trucate == true)
            {
                return await context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {TableName}");
            }
            else
            {
                return await context.Database.ExecuteSqlRawAsync($"DELETE FROM {TableName}");

            }
        }

        public async Task<int> DeleteRecord(string TableName, string TableID, string Id)
        {
            return await context.Database.ExecuteSqlRawAsync($"DELETE FROM {TableName} Where {TableID}='{Id}'");

        }
        public async Task<int> BulkUpdate(string TableName, string TableID, string Id, string Set, string SetValue)
        {
            return await context.Database.ExecuteSqlRawAsync($"UPDATE {TableName} Set {Set}={SetValue} Where {TableID}='{Id}'");

        }


        public async Task<ServiceResponse> RunWebhookAsync(string Name, string Query)
        {
            try
            {
                var data = await context.Database.ExecuteSqlRawAsync(Query);
                var response = new ServiceResponse()
                {
                    LastRun = DateTime.Now,
                    ServiceID = Name,
                    ServiceStatus = ServiceStatus.Successful,
                    Log = $"{data} records updated"

                };
                return response;

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse()
                {
                    LastRun = DateTime.Now,
                    ServiceID = Name,
                    ServiceStatus = ServiceStatus.Failed,
                    Log = $"Error: Exception: {ex.Message} \nInner Exception: {ex.InnerException.Message}"

                };
                return response;

            }
        }



        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}