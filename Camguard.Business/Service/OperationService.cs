using Camguard.Business.IContract;
using Camguard.Business.Service;
using Skylight.DAL;
using Skylight.Data;
using Skylight.Data.Models;
using Skylight.Data.ViewModel;
using Skylight.Mapping;
using Skylight.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business._unitOfWork
{
    public class OperationService:IOperationService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailService emailService;
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        public OperationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            emailService = new EmailService();
            mapper = new Mapper();
        }

       

    


    }
}
