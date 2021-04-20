
using Skylight.Data.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface IWebHookService
    {
        Task<ServiceResponse> RunAsync(string name, string query);
        IEnumerable<ServiceResponse> GetServiceLog(string name, DateTime? date, ServiceStatus? status);
        Task InsertAsync(ServiceResponse model);
    }
}
