using Zalo.Model;

namespace Zalo.Web.Services
{
    public class MessageService : ApiServiceBase
    {
        public MessageService(HttpClient client) : base(client)
        {
            
        }

        public async Task<MessageTextModel> SendMessageText(MessageTextRequest body) => await base.PostAsync<MessageTextModel, MessageTextRequest>("api/Message/text", body);
    }
}
