using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zalo.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zalo.Service
{
    public interface IMessageService
    {
        Task<MessageTextReponse> SendText(MessageTextRequest model);
    }
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly IConfiguration _configuration;

        public MessageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _clientId = configuration["ClientId"] ?? "";
            _clientSecret = configuration["ClientSecret"] ?? "";
        }

        public async Task<MessageTextReponse> SendText(MessageTextRequest model)
        {
            var data = new MessageTextReponse();
            _httpClient.DefaultRequestHeaders.Add("access_token", model.AccessToken);

            string jsonContent = $"{{\"recipient\":{{\"user_id\":\"{model.UserId}\"}},\"message\":{{\"text\":\"{model.MessageText}\"}}}}";

            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://openapi.zalo.me/v3.0/oa/message/cs", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(content);
                if (jsonObject.TryGetValue("error", out JToken fieldToken))
                {
                    var error = fieldToken.ToString();
                    if(error.ToString() != "0")
                    {
                        throw new Exception(fieldToken.ToString());
                    }
                
                }
               data = JsonConvert.DeserializeObject<MessageTextReponse>(content);
            }
            return data;
        }
    }
}
