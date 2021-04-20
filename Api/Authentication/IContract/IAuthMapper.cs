using Api.Authentication.Model;
using Api.Authentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.IContract
{
    public interface IAuthMapper
    {
        public List<UserViewModel> ConvertToUserViewModel(List<ApplicationUser> model);

    }
}
