using System;
using System.Collections.Generic;
using System.Text;

namespace Camguard.Authentication.IContract
{
    public interface IAuthService
    {
        bool IsAuthenticated(string username, string password, string domain,string connectionString);

    }
}
