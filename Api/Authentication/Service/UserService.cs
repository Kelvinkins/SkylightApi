using Api.Authentication.DAL;
using Api.Authentication.IContract;
using Api.Authentication.Mapping;
using Api.Authentication.Model;
using Api.Authentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.Service
{
    public class UserService : IUserService
    {
        private readonly AuthUnitOfWork _unitOfWork;
        IAuthMapper mapper = new AuthMapper();


        public UserService(AuthUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ApplicationRole> GetRoles()
        {
            var roles = _unitOfWork.RoleRepository.Get().OrderByDescending(a => a.Name).ToList();
            return roles;
        }

        public ApplicationUser GetUserByID(string Id)
        {
            var data = _unitOfWork.UserRepository.Get(a => a.Id == Id).FirstOrDefault();
            return data;
        }

        public ApplicationUser GetUserByUserName(string Username)
        {
            var data = _unitOfWork.UserRepository.Get(a => a.UserName == Username).FirstOrDefault();
            return data;
        }

        public List<UserViewModel> GetUsers(string keyword,int limit, int offset)
        {
            var users=_unitOfWork.UserRepository.Get().OrderByDescending(a => a.UserName).Skip(limit * offset).Take(limit).ToList();
            if(!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(a => a.UserName.Contains(keyword) || a.UserName.ToLower() == keyword.ToLower()).ToList();
            }
            var data = mapper.ConvertToUserViewModel(users);
            return data;
        }

        public async Task<(bool status, string message)> UpdateUser(UserViewModel model)
        {
            string message = "";
            try
            {
                var user = _unitOfWork.UserRepository.Get(a => a.Id == model.UserId).FirstOrDefault();
                user.State = model.State;
                if (model.SolID != null)
                {
                    user.SolID = Convert.ToInt32(model.SolID);
                }
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.Save();
                message = "User has been successfully updated";
                return (true, message);

            }
            catch (Exception ex)
            {
                message = $"Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                return (true, message);
            }
        }
    }
}
