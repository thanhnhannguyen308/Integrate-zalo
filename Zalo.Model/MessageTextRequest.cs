using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalo.Model
{
    public class MessageTextRequest
    {
        public string UserId { get; set; } = string.Empty;
        public string MessageText { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
