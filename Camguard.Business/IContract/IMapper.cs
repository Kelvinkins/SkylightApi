
using Skylight.Data.ViewModel;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camguard.Business.IContract
{
   public interface IMapper
    {
        public Employee EmployeeFromViewModel(EmployeeViewModel viewModel);
        public Dependant DependantFromViewModel(DependantViewModel viewModel);
    }
}
