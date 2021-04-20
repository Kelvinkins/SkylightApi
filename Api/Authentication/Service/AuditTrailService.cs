using Api.Authentication.DAL;
using Api.Authentication.IContract;
using Api.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.Service
{
    public class AuditTrailService : IAuditTrailService
    {
        private readonly AuthUnitOfWork _unitOfWork;



        public AuditTrailService(AuthUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AuditTrail> GetAuditTrails()
        {
            var audits = _unitOfWork.AuditTrailRepository.Get().ToList() ;
            return audits;
        }



        public async Task InsertAsync(AuditTrail audit)
        {
             _unitOfWork.AuditTrailRepository.Insert(audit);
           await _unitOfWork.Save();

        }
    }
}
