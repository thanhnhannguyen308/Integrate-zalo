using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Zalo.Model;

namespace Zalo.Service
{
    public interface IAutService
    {
        Task<ZaloAccessTokenResponse> GetAccessToken(string code);
    }

    public class AutService : IAutService
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId; 
        private readonly string _clientSecret;
        private readonly IConfiguration _configuration;

        public AutService(HttpClient httpClient, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _clientId = configuration["ClientId"] ?? "";
            _clientSecret = configuration["ClientSecret"] ?? "";

        }
        public async Task<ZaloAccessTokenResponse> GetAccessToken(string code)
        {
            var data = new ZaloAccessTokenResponse();
            _httpClient.DefaultRequestHeaders.Add("secret_key", _clientSecret);

            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("app_id", _clientId),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code_verifier", "your_code_verifier"),
            };

            var body = new FormUrlEncodedContent(formData);
            var response = await _httpClient.PostAsync("https://oauth.zaloapp.com/v4/oa/access_token", body);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(content);
                if(jsonObject.TryGetValue("error", out JToken fieldToken))
                {
                    var error = fieldToken.ToString();
                    throw new Exception(fieldToken.ToString());
                }
                else
                {
                    data = JsonConvert.DeserializeObject<ZaloAccessTokenResponse>(content);
                }
           
            }
            return data;
        }
    }
}
