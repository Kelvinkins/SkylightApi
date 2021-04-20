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
    public class CompaniesController : ControllerBase
    {

        private ICompanyService _companyService;
        private IMapper mapper = new Mapper();

        public CompaniesController(ILogger<CompaniesController> logger, UnitOfWork unitOfWork)
        {
            _companyService = new CompanyService(unitOfWork);
        }



        [HttpGet]
        [Route("List")]
        public IEnumerable<Company> Get(string keyword, int limit, int offset, Status? status)
        {
            IEnumerable<Company> data = new List<Company>();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = _companyService.GetBySearchTerm(keyword);

            }
            else
            {
                switch (status)
                {
                    case Status.Active:
                        data = _companyService.Active().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    case Status.InActive:
                        data = _companyService.InActive().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
                        break;
                    default:
                        data = _companyService.GetAll().OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
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
                    data = _companyService.GetActiveCount();
                    break;
                case Status.InActive:
                    data = _companyService.GetInActiveCount();
                    break;
                default:
                    data = _companyService.GetAllCount();
                    break;
            }
            return data;

        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Company model)
        {
            var result = await _companyService.Update(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(Company model)
        {
            var result = await _companyService.AddAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("AddBulk")]
        public async Task<IActionResult> AddBulkAsync(List<Company> model)
        {
            var result = await _companyService.AddBulkAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }



    }
}
