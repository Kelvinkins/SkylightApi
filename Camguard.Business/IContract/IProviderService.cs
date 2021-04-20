
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface IProviderService
    {

        List<Provider> GetAll();
        List<Provider> Active();
        List<Provider> InActive();
        Provider GetByID(int ProviderID);
        List<Provider> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(Provider model);
        Task<(bool status, string message)> AddAsync(Provider model);
        Task<(bool status, string message)> AddBulkAsync(List<Provider> model);
    }
}
