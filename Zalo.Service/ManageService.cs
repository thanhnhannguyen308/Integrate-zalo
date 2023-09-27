using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zalo.Model;

namespace Zalo.Service
{
    public interface IManageService
    {
        Task<InfoOAReponse> GetOAInfo(string accessToken);
    }

    public class ManageService : IManageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly IConfiguration _configuration;

        public ManageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _clientId = configuration["ClientId"] ?? "";
            _clientSecret = configuration["ClientSecret"] ?? "";
        }

        public async Task<InfoOAReponse> GetOAInfo(string accessToken)
        {
            var data = new InfoOAReponse();
            _httpClient.DefaultRequestHeaders.Add("access_token", accessToken);

            var response = await _httpClient.GetAsync("https://openapi.zalo.me/v2.0/oa/getoa");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(content);
                if (jsonObject.TryGetValue("error", out JToken fieldToken))
                {
                    var error = fieldToken.ToString();
                    if (error.ToString() != "0")
                    {
                        throw new Exception(fieldToken.ToString());
                    }
                }
                data = JsonConvert.DeserializeObject<InfoOAReponse>(content);
            }
            return data;
        }
    }
}