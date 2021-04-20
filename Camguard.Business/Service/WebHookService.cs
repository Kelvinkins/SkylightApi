using Camguard.Business._unitOfWork;
using Camguard.Business.IContract;

using Skylight.DAL;
using Skylight.Data.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight.Business.Service
{
    public class WebHookService : IWebHookService
    {
        private readonly UnitOfWork _unitOfWork;
       public WebHookService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<ServiceResponse> RunAsync(string name, string query)
        {
          
            var response=await _unitOfWork.RunWebhookAsync(name, query);
            return response;
        }

        public IEnumerable<ServiceResponse>GetServiceLog(string name, DateTime? date,ServiceStatus? status)
        {
            var data =  _unitOfWork.ServiceResponseRepository.Get();
            if(!string.IsNullOrEmpty(name))
            {
                data = data.Where(a => a.ServiceID == name);
            }
            if(date!=null)
            {
                data = data.Where(a => a.LastRun.Date == date.Value.Date);
            }
            if(status!=null)
            {
                data = data.Where(a => a.ServiceStatus == status);
            }

            return data;
        }

        public async Task InsertAsync(ServiceResponse model)
        {
            _unitOfWork.ServiceResponseRepository.Insert(model);
            await _unitOfWork.SaveAsync();
        }
    }
}
