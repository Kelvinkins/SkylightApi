using Camguard.Business.IContract;
using Camguard.Business.Service;
using Camguard.Data.DAL;
using Camguard.Externals.IContract;
using Camguard.Externals.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skylight.Business.Service;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyPoliciesController : ControllerBase
    {

        private ICompanyPolicyService _companyPolicyService;
        private IMapper mapper = new Mapper();

        public CompanyPoliciesController(ILogger<CompanyPoliciesController> logger, UnitOfWork unitOfWork)
        {
            _companyPolicyService = new CompanyPolicyService(unitOfWork);
        }



        [HttpGet]
        [Route("List")]
        public IEnumerable<CompanyPolicy> Get(int CompanyID,string keyword, int limit, int offset, Status? status)
        {
            IEnumerable<CompanyPolicy> data = new List<CompanyPolicy>();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = _companyPolicyService.GetBySearchTerm(keyword);

            }
            else
            {
                switch (status)
                {
                    case Status.Active:
                        data = _companyPolicyService.Active().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    case Status.InActive:
                        data = _companyPolicyService.InActive().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    default:
                        data = _companyPolicyService.GetAll(CompanyID).OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
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
                    data = _companyPolicyService.GetActiveCount();
                    break;
                case Status.InActive:
                    data = _companyPolicyService.GetInActiveCount();
                    break;
                default:
                    data = _companyPolicyService.GetAllCount();
                    break;
            }
            return data;

        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(CompanyPolicy model)
        {
            var result = await _companyPolicyService.Update(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(CompanyPolicy model)
        {
            var result = await _companyPolicyService.AddAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("AddBulk")]
        public async Task<IActionResult> AddBulkAsync(List<CompanyPolicy> model)
        {
            var result = await _companyPolicyService.AddBulkAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }
    }

}
