using Api.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.IContract
{
    interface IAuditTrailService
    {
        List<AuditTrail> GetAuditTrails();
        Task InsertAsync(AuditTrail audit);

    }
}
