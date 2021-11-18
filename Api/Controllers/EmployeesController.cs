using Camguard.Business.IContract;

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
using Api.Service;
using Skylight.Data.Models;

namespace Camguard.Api.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeService _employeeService;
        private IMapper mapper = new Mapper();

        public EmployeesController(ILogger<EmployeesController> logger, EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpGet]
        [Route("List")]
        public IEnumerable<Employee> Get(string keyword, int limit, int offset, Status? status)
        {
            var data=  _employeeService.Get();
            data= data.OrderByDescending(a => a.RegistrationDate).Skip(limit * offset).Take(limit).ToList();
            return data;
        }


        [HttpGet]
        [Route("States")]
        public IEnumerable<State> GetStates()
        {
            var data = _employeeService.GetStates();
            return data;
        }
        
        [HttpGet]
        [Route("Providers")]
        public IEnumerable<Provider> GetProviders()
        {
            var data = _employeeService.GetProviders();
            return data;
        } 
        
        
        [HttpGet]
        [Route("Companies")]
        public IEnumerable<Company> GetCompanies()
        {
            var data = _employeeService.GetCompanies();
            return data;
        }


        [HttpGet]
        [Route("CompanyPolicies")]
        public IEnumerable<CompanyPolicy> CompanyPolicies()
        {
            var data = _employeeService.GetCompanyPolicies();
            return data;
        }

        [HttpGet]
        [Route("Plans")]
        public IEnumerable<Plan> Plans()
        {
            var data = _employeeService.GetPlans();
            return data;
        }

        //[HttpGet]
        //[Route("Count")]
        //public int Count(Status? status)
        //{
        //    int data = 0;
        //    switch (status)
        //    {
        //        case Status.Active:
        //            data = _employeeService.GetActiveCount();
        //            break;
        //        case Status.InActive:
        //            data = _employeeService.GetInActiveCount();
        //            break;
        //        default:
        //            data = _employeeService.GetAllCount();
        //            break;
        //    }
        //    return data;

        //}


        //[HttpPut]
        //[Route("Update")]
        //public async Task<IActionResult> Update(Employee model)
        //{
        //    var result = await _employeeService.Update(model);
        //    return Ok(new
        //    {
        //        result.status,
        //        result.message
        //    });

        //}


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(Employee model)
        {
            var result = await _employeeService.CreateAsync(model);
            return Ok(new
            {
                result
            });

        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync(Employee model)
        {
            var result = await _employeeService.Update(model.Id,model);
            return Ok(new
            {
                result
            });

        }


        //[HttpPost]
        //[Route("AddBulk")]
        //public async Task<IActionResult> AddBulkAsync(List<EmployeeViewModel> employees,List<DependantViewModel> dependants)
        //{
        //    var result = await _employeeService.AddBulkAsync(employees, dependants);
        //    return Ok(new
        //    {
        //        result.status,
        //        result.message
        //    });

        //}

    }
}
