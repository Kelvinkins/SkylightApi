using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface ICompanyService
    {

        List<Company> GetAll();
        List<Company> Active();
        List<Company> InActive();
        Company GetByID(int EmployeeID);
        List<Company> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(Company model);
        Task<(bool status, string message)> AddAsync(Company model);
        Task<(bool status, string message)> AddBulkAsync(List<Company> model);
    }
}
