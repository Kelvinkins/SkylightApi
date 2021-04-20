using Camguard.Business.IContract;
using Camguard.Business.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skylight.DAL;
using Skylight.Mapping;
using Skylight.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvidersController : ControllerBase
    {

        private IProviderService _providerService;
        private IMapper mapper = new Mapper();

        public ProvidersController(ILogger<ProvidersController> logger, UnitOfWork unitOfWork)
        {
            _providerService = new ProviderService(unitOfWork);
        }



        [HttpGet]
        [Route("List")]
        public IEnumerable<Provider> Get(string keyword, int limit, int offset, Status? status)
        {
            IEnumerable<Provider> data = new List<Provider>();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = _providerService.GetBySearchTerm(keyword);

            }
            else
            {
                switch (status)
                {
                    case Status.Active:
                        data = _providerService.Active().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    case Status.InActive:
                        data = _providerService.InActive().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    default:
                        data = _providerService.GetAll().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;

                }
            }
            return data;
        }


        [HttpGet]
        [Route("Count")]
        public int Count(Status? status)
        {
            int data = 0;
            switch (status)
            {
                case Status.Active:
                    data = _providerService.GetActiveCount();
                    break;
                case Status.InActive:
                    data = _providerService.GetInActiveCount();
                    break;
                default:
                    data = _providerService.GetAllCount();
                    break;
            }
            return data;

        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Provider model)
        {
            var result = await _providerService.Update(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(Provider model)
        {
            var result = await _providerService.AddAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("AddBulk")]
        public async Task<IActionResult> AddBulkAsync(List<Provider> model)
        {
            var result = await _providerService.AddBulkAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }



    }
}
