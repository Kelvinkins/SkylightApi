using System;
using System.Collections.Generic;
using System.Text;

namespace Skylight.Data.Models
{
    public class HmoDatabaseSettings : IHmoDatabaseSettings
    {
        public string EmployeesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string StatesCollectionName { get; set; }
        public string ProvidersCollectionName { get; set; }
        public string CompaniesCollectionName { get; set; }
        public string CompanyPoliciesCollectionName { get; set; }
        public string PlansCollectionName { get; set; }

    }

    public interface IHmoDatabaseSettings
    {
        string EmployeesCollectionName { get; set; }
        string StatesCollectionName { get; set; }
        string ProvidersCollectionName { get; set; }
        string CompaniesCollectionName { get; set; }
        string CompanyPoliciesCollectionName { get; set; }
        string PlansCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

