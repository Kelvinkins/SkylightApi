using Api.Authentication.DAL;
using Api.Authentication.IContract;
using Api.Authentication.Model;
using Api.Authentication.Service;
using Api.Authentication.ViewModel;
using IdentityModel.Client;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IConfiguration _configuration;
        private IAuditTrailService auditTrailService;
        private IHttpContextAccessor _accessor;
        IConfiguration Configuration;
        LDapService ldapService;
        public PassportController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
             AuthUnitOfWork unitOfWork,
            IHttpContextAccessor accessor)
        {
            userService = new UserService(unitOfWork);
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            Configuration = configuration;
            _accessor = accessor;
            auditTrailService = new AuditTrailService(unitOfWork);
        }




        /// <summary>
        /// returns a list of login audit trails
        /// </summary>
        /// <param name="limit">limit</param>
        /// <param name="offset"> offset</param>
        /// <returns> returns a list of AuditTrail Object</returns>
        [HttpGet]
        [Route("Trails")]
        //[Authorize]
        public List<AuditTrail> Trails(int limit, int offset)
        {
            var trails = auditTrailService.GetAuditTrails().OrderByDescending(a => a.DateTime).Skip(limit * offset).Take(limit).ToList();
            return trails;
        }






        /// <summary>
        /// Logs in the user and generates access token, if the user does not exist and has been validated on the
        /// active directory, creates the user and continue witht the login process.
        /// </summary>
        /// <param name="model">The user to login</param>
        /// <returns>returns access token if the login succeeds or Unthorized if the login fails</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            var IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();


            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
            {

                if (await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    var audit = new AuditTrail();
                    audit.DateTime = DateTime.Now;
                    audit.Description = "Logged in successfully";
                    audit.IpAddress = IpAddress;
                    audit.Username = user.UserName;
                    await auditTrailService.InsertAsync(audit);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        Username = user.UserName
                    });
                }
            }

            return Unauthorized();


        }





        /// <summary>
        /// Registers the user
        /// </summary>
        /// <param name="model">The user to register</param>
        /// <returns>returns status and message</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Id = model.Username,
                Email = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                State = model.State,
                SolID = model.SolID
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            else
            {
                if (!await roleManager.RoleExistsAsync(model.Role))
                {
                    await userManager.AddToRoleAsync(user, model.Role);
                    return Ok(new Response { Status = "Success", Message = "User created successfully!" });

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "The Specified user role does not exist or has been discontinued" });

                }
            }
        }

        /// <summary>
        /// Bulk registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BulkRegistration")]
        public async Task<IActionResult> BulkRegistration([FromBody] List<RegisterViewModel> model)
        {
            int result = 0;
            foreach (var item in model)
            {
                try
                {
                    await Register(item);
                    result = result + 1;
                }
                catch (Exception ex)
                {

                }
            }
            return Ok(new Response { Status = "Success", Message = $"Users Registered successfully" });

        }



        /// <summary>
        /// Changes user password
        /// </summary>
        /// <param name="currentPassword">The existing password</param>
        /// <param name="newPassword">The new password</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            var user = userService.GetUserByUserName(User.Identity.Name);
            await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return Ok(new Response { Status = "Success", Message = "Password changed successfully!" });

        }
        /// <summary>
        /// Adds user to an existing role, if the role does not exist, creates it on fly
        /// </summary>
        /// <param name="model">The user ID and the Role to add the user to</param>
        /// <returns>returns status and message</returns>
        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole([FromBody] UserRoleViewModel model)
        {

            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "User does not exists!" });

            if (!await roleManager.RoleExistsAsync(model.UserRole))
                await roleManager.CreateAsync(new ApplicationRole(model.UserRole));

            if (await roleManager.RoleExistsAsync(model.UserRole))
            {

                await userManager.AddToRoleAsync(user, model.UserRole);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


        /// <summary>
        /// Adds a new role to the Database
        /// </summary>
        /// <param name="role">The role to add</param>
        /// <returns>returns http status code</returns>
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new ApplicationRole(role) { Id = role, DateTime = DateTime.Now, ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = role.ToUpper() });
                return Ok(new Response { Status = "Success", Message = "Role created successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, new Response { Status = "Error", Message = "Role already exists!" });
            }

        }


        /// <summary>
        /// returns a list of users
        /// </summary>
        /// <param name="limit">limit of the record</param>
        /// <param name="offset">offset of the record</param>
        /// <param name="keyword">search term for searching for a user</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Users")]
        public async Task<List<UserViewModel>> GetUserAsync(string keyword, int limit, int offset)
        {
            var data = new List<UserViewModel>();
            var users = userService.GetUsers(keyword, limit, offset);
            foreach (var user in users)
            {
                var newUser = new UserViewModel()
                {
                    UserName = user.UserName,
                    UserId = user.UserId,
                    SolID = user.SolID,
                    State = user.State,
                };
                var appUser = userService.GetUserByID(user.UserId);
                var roles = await userManager.GetRolesAsync(appUser);
                newUser.Role = roles.FirstOrDefault();
                data.Add(newUser);

            }
            return data;
        }


        /// <summary>
        /// Updates the user's State, SolID, Username and Role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserViewModel model)
        {

            var result = await userService.UpdateUser(model);
            if (result.status)
            {
                if (await roleManager.RoleExistsAsync(model.Role))
                {
                    var user = userService.GetUserByID(model.UserId);
                    await userManager.AddToRoleAsync(user, model.Role);
                }
                else
                {
                    string message = "User updated successfully but could not be added to the specified role because the role does not exist";
                    return Ok(new { result.status, message });
                }
            }
            return Ok(new
            {
                result.status,
                result.message
            });

        }
        /// <summary>
        /// Gets the List of roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Roles")]
        public List<ApplicationRole> Roles()
        {
            var roles = userService.GetRoles();
            return roles;
        }


    }






}



