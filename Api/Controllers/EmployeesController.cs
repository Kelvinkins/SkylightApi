using Camguard.Business.IContract;
using Camguard.Business.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Skylight.DAL;
using Skylight.Mapping;
using Skylight.Models;
using Skylight.Models.Enums;
using Skylight.Data.ViewModel;

namespace Camguard.Api.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {

        private IEmployeeService _employeeService;
        private IMapper mapper = new Mapper();

        public EmployeesController(ILogger<EmployeesController> logger, UnitOfWork unitOfWork)
        {
            _employeeService = new EmployeeService(unitOfWork);
        }



        [HttpGet]
        [Route("List")]
        public IEnumerable<Employee> Get(string keyword, int limit, int offset, Status? status)
        {
            IEnumerable<Employee> data = new List<Employee>();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = _employeeService.GetBySearchTerm(keyword);

            }
            else
            {
                switch (status)
                {
                    case Status.Active:
                        data = _employeeService.Active();
                        break;
                    case Status.InActive:
                        data = _employeeService.InActive();
                        break;
                    default:
                        data = _employeeService.GetAll();
                        break;

                }
            }
            data=data.OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit);
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
                    data = _employeeService.GetActiveCount();
                    break;
                case Status.InActive:
                    data = _employeeService.GetInActiveCount();
                    break;
                default:
                    data = _employeeService.GetAllCount();
                    break;
            }
            return data;

        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Employee model)
        {
            var result = await _employeeService.Update(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(Employee model)
        {
            var result = await _employeeService.AddAsync(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }


        [HttpPost]
        [Route("AddBulk")]
        public async Task<IActionResult> AddBulkAsync(List<EmployeeViewModel> employees,List<DependantViewModel> dependants)
        {
            var result = await _employeeService.AddBulkAsync(employees, dependants);
            return Ok(new
            {
                result.status,
                result.message
            });

        }

    }
}
