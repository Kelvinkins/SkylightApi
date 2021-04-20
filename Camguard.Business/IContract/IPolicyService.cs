
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface IPolicyService
    {
        List<Policy> GetAll();
        List<Policy> Active();
        List<Policy> InActive();
        Policy GetByID(string ID);
        List<Policy> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(Policy model);
        Task<(bool status, string message)> AddAsync(Policy model);
        Task<(bool status, string message)> AddBulkAsync(List<Policy> model);
    }
}
