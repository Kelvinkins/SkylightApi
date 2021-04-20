
using Skylight.Data.ViewModel;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        List<Employee> Active();
        List<Employee> InActive();
        Employee GetByID(int ID);
        List<Employee> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(Employee model);      
        Task<(bool status, string message)> AddAsync(Employee model);
        Task<(bool status, string message)> AddBulkAsync(List<EmployeeViewModel> employees, List<DependantViewModel> dependants);


    }
}
