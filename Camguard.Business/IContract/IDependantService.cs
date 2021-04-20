using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface IDependantService
    {

        List<Dependant> GetAll(int EmployeeID);
        List<Dependant> Active();
        List<Dependant> InActive();
        Dependant GetByID(string ID);
        List<Dependant> GetBySearchTerm(string keyword);

        int GetActiveCount();
        int GetInActiveCount();
        int GetAllCount();
        Task<(bool status, string message)> Update(Dependant model);
        Task<(bool status, string message)> AddAsync(Dependant model);
        Task<(bool status, string message)> AddBulkAsync(List<Dependant> model);
    }
}
