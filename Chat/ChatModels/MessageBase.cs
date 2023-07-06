using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MessageBase
    {
       public TextMessage? TextMessage { get;  set; }

       public ImageMessage? ImageMessage { get; set; }

       public DeclarationMessage? DeclarationMessage { get; set; }
    }
}
