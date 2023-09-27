using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalo.Model
{
    public class InfoOAReponse
    {
        [JsonProperty("data")]
        public InfoData Data { get; set; }
        [JsonProperty("error")]
        public int Error { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class InfoData
    {
        [JsonProperty("oa_id")]
        public string OAId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }
        [JsonProperty("oa_type")]
        public int OAType { get; set; }
        [JsonProperty("cate_name")]
        public string CateName { get; set; }
        [JsonProperty("num_follower")]
        public int NumFolower { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set;}
        [JsonProperty("cover")]
        public string Cover { get; set; }
        [JsonProperty("package_name")]
        public string PackageName { get; set; }
    }
}
