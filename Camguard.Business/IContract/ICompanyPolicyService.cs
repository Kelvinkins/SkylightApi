using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface ICompanyPolicyService
    {

        List<CompanyPolicy> GetAll(int CompanyID);
        List<CompanyPolicy> Active();
        List<CompanyPolicy> InActive();
        CompanyPolicy GetByID(string ID);
        List<CompanyPolicy> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(CompanyPolicy model);
        Task<(bool status, string message)> AddAsync(CompanyPolicy model);
        Task<(bool status, string message)> AddBulkAsync(List<CompanyPolicy> model);

    }
}
