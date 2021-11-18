
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface IPolicyService
    {
        List<Plan> GetAll();
        List<Plan> Active();
        List<Plan> InActive();
        Plan GetByID(string ID);
        List<Plan> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(Plan model);
        Task<(bool status, string message)> AddAsync(Plan model);
        Task<(bool status, string message)> AddBulkAsync(List<Plan> model);
    }
}
