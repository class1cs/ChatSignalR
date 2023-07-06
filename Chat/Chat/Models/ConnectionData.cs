using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class ConnectionData
    {
        public string? IP { get; set; }

        public int? Port { get; set; }

        public string? Nick { get; set; }

        public Uri? UserPic { get; set; }
    }
}
