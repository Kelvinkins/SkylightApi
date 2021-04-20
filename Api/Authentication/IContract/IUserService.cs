using Api.Authentication.Model;
using Api.Authentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.IContract
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers(string keyword,int limit, int offset);
        List<ApplicationRole> GetRoles();
        Task<(bool status, string message)> UpdateUser(UserViewModel model);
        ApplicationUser GetUserByID(string ID);
        public ApplicationUser GetUserByUserName(string Username);





    }
}
