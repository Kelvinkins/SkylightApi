using Camguard.Authentication.IContract;
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Text;

namespace Camguard.Authentication.Service
{
   public class AuthService : IAuthService
    {
        public bool IsAuthenticated(string username, string password, string domain,string connectionString)
        {
            Boolean authenticated = false;
            using (LdapConnection connection = new LdapConnection(connectionString))
            {
                try
                {
                    username = username +"@"+ domain;
                    connection.AuthType = AuthType.Basic;
                    connection.SessionOptions.ProtocolVersion = 3;
                    var credential = new NetworkCredential(username, password);
                    connection.Bind(credential);
                    authenticated = true;
                    return authenticated;
                }
                catch (LdapException ex)
                {
                    return authenticated;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

    }
}
