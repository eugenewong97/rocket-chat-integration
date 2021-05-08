using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rocket.chat.integration.Extensions;
using rocket.chat.integration.Models;


namespace rocket.chat.integration.Controllers
{

    [ApiController]
    [Route("/api/v1")]
    public class RocketChatLogin : ControllerBase
    {

        [Route("heathcheck")]
        public IActionResult HeathCheck()
        {
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel userCredential)
        {

            var rocketchatApi = new RocketChatApi();

            var user = userCredential.user;
            var password = userCredential.password;

            if(user is null && password is null)
            {
                return BadRequest("Username and password cannot be empty");
            }

            var loginApi = await rocketchatApi.LoginApi(user, password);

            if(loginApi.IsSuccessStatusCode)
            {
                var loginContent = await loginApi.Content.ReadAsStringAsync();
                var jsonResponse = JsonSerializer.Deserialize<LoginResultModel>(loginContent);

                return Ok(jsonResponse);
            }

            return NotFound();
        }

        public IActionResult LoginAuth()
        {


            return Ok();
        }
    }
}
