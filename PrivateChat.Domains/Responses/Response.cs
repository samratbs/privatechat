using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Domains.Responses
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public bool Found  { get; set; }
    }
}
