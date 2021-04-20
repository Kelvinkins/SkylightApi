using Skylight.Data.Models;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
    public interface ICapitationService
    {
         Task<(bool status, string message)> Process(CapitationMaster model);
        Task<(bool status, ServiceResponse message)> PublishCapitation();


    }
}
