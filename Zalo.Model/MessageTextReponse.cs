using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalo.Model
{
    public class MessageTextReponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
        [JsonProperty("error")]
        public int Error { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class Data
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; } 
        [JsonProperty("user_id")]
        public string UserId { get; set; } 
    }
}
