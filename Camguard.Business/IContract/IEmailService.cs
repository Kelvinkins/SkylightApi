using Skylight.DAL;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.IContract
{
   public  interface IEmailService
    {
        Task SendMail(UnitOfWork service, string subject, string entityID, string message, Module module, byte[] file, string fileName);

    }
}
