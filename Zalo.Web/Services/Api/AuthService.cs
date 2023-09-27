using Zalo.Model;

namespace Zalo.Web.Services
{
    public class AuthService : ApiServiceBase
    {
        public AuthService(HttpClient client) : base(client)
        {
            
        }

        public async Task<ZaloAccessTokenModel> GetAccessToken(string code) => await base.PostAsync<ZaloAccessTokenModel, string>("api/Auth/access-token", code);
    }
}
