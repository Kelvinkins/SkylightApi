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
    public class CapitationsController : ControllerBase
    {

        private ICapitationService _capitationService;
        private IMapper mapper = new Mapper();

        public CapitationsController(ILogger<CapitationsController> logger, UnitOfWork unitOfWork)
        {
            _capitationService = new CapitationService(unitOfWork);
        }



        [HttpPost]
        [Route("Process")]
        public async Task<IActionResult> Process(CapitationMaster model)
        {
            var result = await _capitationService.Process(model);
            return Ok(new
            {
                result.status,
                result.message
            });

        }

    }
}
