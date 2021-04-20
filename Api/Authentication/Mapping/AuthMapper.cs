using Api.Authentication.IContract;
using Api.Authentication.Model;
using Api.Authentication.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.Mapping
{
    public class AuthMapper: IAuthMapper
    {
      
        public List<UserViewModel> ConvertToUserViewModel(List<ApplicationUser> model)
        {
            List<UserViewModel> list = new List<UserViewModel>();
            foreach(var item in model)
            {
                var data = new UserViewModel()
                {
                    UserName = item.UserName,
                    UserId = item.Id,
                    SolID = item.SolID,
                    State = item.State,
                };
                list.Add(data);

            }
            return list;
        }
    }

}
