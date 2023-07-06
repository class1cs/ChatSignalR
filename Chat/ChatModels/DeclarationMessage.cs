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
    public class DeclarationMessage { 
        public string Time { get; set; } = DateTime.Now.ToString("HH:mm:ss", new CultureInfo("ru-RU"));

        public string Declaration { get; set; }
    }
}
