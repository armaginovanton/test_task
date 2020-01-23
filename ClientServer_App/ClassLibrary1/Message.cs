using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer_App
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Ip { get; set; }
        public DateTime GetDateTime { get; set; }
    }
}
