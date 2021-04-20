using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "CamguardClient101",
                ClientName = "Camguard Dashboard Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, 
                AllowedScopes = new List<string> {"api1.read"}
            }
        };
        }
    }
}
