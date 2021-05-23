using System;
using System.Text.Json.Serialization;

namespace rocket.chat.integration.Models
{
    public class LoginModel
    {
        [JsonPropertyName("user")]
        public string? User { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
     
    }
}
