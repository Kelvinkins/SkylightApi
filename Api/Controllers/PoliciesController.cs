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
    public class PoliciesController : ControllerBase
    {

        private IPolicyService _policyService;
        private IMapper mapper = new Mapper();

        public PoliciesController(ILogger<PoliciesController> logger, UnitOfWork unitOfWork)
        {
            _policyService = new PolicyService(unitOfWork);
        }



        [HttpGet]
        [Route("List")]
        public IEnumerable<Plan> Get(string keyword, int limit, int offset, Status? status)
        {
            IEnumerable<Plan> data = new List<Plan>();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = _policyService.GetBySearchTerm(keyword);

            }
            else
            {
                switch (status)
                {
                    case Status.Active:
                        data = _policyService.Active().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    case Status.InActive:
                        data = _policyService.InActive().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    default:
                        data = _policyService.GetAll().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
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
                    data = _policyService.GetActiveCount();
                    break;
                case Status.InActive:
                    data = _policyService.GetInActiveCount();
                    break;
                default:
                    data = _policyService.GetAllCount();
                    break;
            }
            return data;

        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Plan model)
        {
            var result = await _policyService.Update(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(Plan model)
        {
            var result = await _policyService.AddAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("AddBulk")]
        public async Task<IActionResult> AddBulkAsync(List<Plan> model)
        {
            var result = await _policyService.AddBulkAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }



    }
}
