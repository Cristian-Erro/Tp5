using AppFakeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppFakeStore.Utils;

namespace AppFakeStore.Services
{
    public class LoginService : ILoginService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public LoginService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> AuthenticateAsync(Login login)
        {
            var response = await client.PostAsJsonAsync(Constants.LoginEndpoint, login);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>(options);
                return result.ContainsKey("token") ? result["token"] : null;
            }

            return null;
        }
    }
}
