using IdentityModel;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Authentication.Service
{
    public class TokenService
    {
        HttpClient httpClient = new HttpClient();
        public async Task<TokenResponse> RequestTokenAsync(string username, string password)
        {
            var identityServerResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://localhost:44390/connect/token",
                GrantType = "password",

                ClientId = "CamguardClient101",
                ClientSecret = "secret_for_the_consoleapp",
                Scope = "Camguard Api",

                UserName = username,
                Password = password.ToSha256()
            });
            return identityServerResponse;
        }
    }
}
