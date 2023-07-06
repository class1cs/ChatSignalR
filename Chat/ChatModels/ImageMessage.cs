using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chat.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ImageMessage
    {
        public string Username { get; set; }

        public string Time { get; set; } = DateTime.Now.ToString("HH:mm:ss", new CultureInfo("ru-RU"));

        public byte[] AddedImage { get; set; }

        public Uri UserPic { get; set; }
    }
}
