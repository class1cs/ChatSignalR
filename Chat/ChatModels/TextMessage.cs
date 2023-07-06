using System;
using System.Drawing;
using System.Globalization;
using PropertyChanged;

namespace Chat.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TextMessage
    {
        public string Time { get; set; } = DateTime.Now.ToString("HH:mm:ss", new CultureInfo("ru-RU"));

        public string Username { get; set; }

        public string Data { get; set; }

        public Uri? UserPic { get; set; }


    }
}