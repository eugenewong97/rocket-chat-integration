using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using rocket.chat.integration.Models;

namespace rocket.chat.integration.Extensions
{
    public class RocketChatApi
    {

        public static readonly HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> LoginApi(string username, string userPassword)
        {

            var loginModel = new LoginModel()
            {
                user = username,
                password = userPassword
            };

            var loginUrl = $"{RocketChatServer.BASE_URL}/api/v1/login";
            var json = JsonSerializer.Serialize<LoginModel>(loginModel);           

            var postData = await client.PostAsync(loginUrl, new StringContent(json, Encoding.UTF8, "application/json"));

            return postData;

        }
    }
}
