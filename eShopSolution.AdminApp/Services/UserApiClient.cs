using eShopSolution.ViewModels.System.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            //chuyển ra dạng Json
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            //gọi Api
            client.BaseAddress = new Uri("http://localhost:5001");
            var resopne = await client.PostAsync("/api/users/authenticate", httpContent);

            //gọi ra token từ biến respone
            var token = await resopne.Content.ReadAsStringAsync();
            return token;
        }
    }
}