using Zalo.Model;

namespace Zalo.Web.Services
{
    public class ManageService : ApiServiceBase
    {
        public ManageService(HttpClient client) : base(client)
        {
            
        }

        public async Task<InfoOAModel> GetOAInfo(string accessToken) => await base.PostAsync<InfoOAModel, string>("api/Manage/GetOA", accessToken);
    }
}
