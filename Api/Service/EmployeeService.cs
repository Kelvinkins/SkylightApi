using MongoDB.Driver;
using Skylight.Data.Models;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        private readonly IMongoCollection<State> _states;
        private readonly IMongoCollection<Provider> _providers;
        private readonly IMongoCollection<Company> _companies;
        private readonly IMongoCollection<CompanyPolicy> _companyPolicies;
        private readonly IMongoCollection<Plan> _plans;

        public EmployeeService(IHmoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);
            _states = database.GetCollection<State>(settings.StatesCollectionName);
            _providers = database.GetCollection<Provider>(settings.ProvidersCollectionName);
            _companies = database.GetCollection<Company>(settings.CompaniesCollectionName);
            _companyPolicies = database.GetCollection<CompanyPolicy>(settings.CompanyPoliciesCollectionName);
            _plans = database.GetCollection<Plan>(settings.PlansCollectionName);
        }

        public List<Employee> Get() =>
            _employees.Find(employee => true).ToList();

        public Employee Get(string id) =>
            _employees.Find<Employee>(employee => employee.Id == id).FirstOrDefault();

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _employees.InsertOneAsync(employee);
            return employee;
        }

        public async Task<Employee> Update(string id, Employee employeeIn)
        {
           await _employees.ReplaceOneAsync(employee => employee.Id == id, employeeIn);
            return employeeIn;
        }

        public void Remove(Employee employeeIn) =>
            _employees.DeleteOne(employee => employee.Id == employeeIn.Id);

        public void Remove(string id) =>
            _employees.DeleteOne(employee => employee.Id == id);


        public List<State> GetStates() =>
           _states.Find(state => true).ToList();

        public List<Provider> GetProviders() =>
        _providers.Find(provider => true).ToList();

        public List<Company> GetCompanies() =>
        _companies.Find(company => true).ToList();


        public List<CompanyPolicy> GetCompanyPolicies() =>
        _companyPolicies.Find(companyPolicy => true).ToList();   
        
        public List<Plan> GetPlans() =>
        _plans.Find(plan => true).ToList();
    }

}
