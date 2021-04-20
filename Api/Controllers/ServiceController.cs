using Camguard.Business.IContract;
using Camguard.Business.Service;
using Camguard.Data.Common;
using Camguard.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skylight.Business.Service;
using Skylight.DAL;
using Skylight.Data.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {


        private readonly IWebHookService webHookService;
        private readonly ICapitationService capitationService;
        public ServiceController(UnitOfWork unitOfWork)
        {
            webHookService = new WebHookService(unitOfWork);
            capitationService = new CapitationService(unitOfWork);

        }

        /// <summary>
        /// Runs various services and reports the status and log to the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Run")]
        public async Task<IActionResult> RunAsync()
        {
           var service1=await capitationService.PublishCapitation();
            await webHookService.InsertAsync(service1.message);

            //var service1 = await webHookService.RunAsync("SetOnUsToTrue", StaticQueries.SetOnUsToTrue);

            //var service2 = await webHookService.RunAsync("SetOnUsToFalse", StaticQueries.SetOnUsToFalse);
            //await webHookService.InsertAsync(service2);


            //var service3 = await webHookService.RunAsync("UpdateCardless", StaticQueries.UpdateCardless);
            //await webHookService.InsertAsync(service3);

            //var service4 = await webHookService.RunAsync("UpdateMasterSettlement", StaticQueries.UpdateMasterSettlement);
            //await webHookService.InsertAsync(service4);

            //var service5 = await webHookService.RunAsync("UpdateSettlementVerve", StaticQueries.UpdateSettlementVerve);
            //await webHookService.InsertAsync(service5);

            //var service6 = await webHookService.RunAsync("UpdateAtmStatus", StaticQueries.UpdateAtmStatus);
            //await webHookService.InsertAsync(service6);
            return Ok();
        }

        /// <summary>
        /// Gets service logs
        /// </summary>
        /// <param name="name">Name of the service</param>
        /// <param name="date">date of the service</param>
        /// <param name="status">Status service</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ServiceLog")]
        public  IEnumerable<ServiceResponse> GetServiceLog(string name, DateTime? date, ServiceStatus? status)
        {
            var data = webHookService.GetServiceLog(name, date, status);
            return data;
        }
    }
}