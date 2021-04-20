using Camguard.Authentication.IContract;
using Camguard.Authentication.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.Service
{
    public class LDapService
    {
        public LDapService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        IAuthService authService = new AuthService();

        public bool IsAuthenticated(string username,string password)
        {
           var result =  authService.IsAuthenticated(username, password, Configuration.GetConnectionString("domain"), Configuration.GetConnectionString("ActiveDirectoryConnectionString"));
            return result;
        }
    }
}
