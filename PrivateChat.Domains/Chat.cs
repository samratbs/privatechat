using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Domains
{
    public class Chat
    {
        public string? Username { get; set; }
        public string? Message { get; set; }
        public List<string>? ChatMessages { get; set; }
    }
}
