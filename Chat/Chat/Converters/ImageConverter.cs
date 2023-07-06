using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Chat.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = (Uri)value;
                src.DecodePixelHeight = 1280;//Your wanted image height
                src.DecodePixelWidth = 780; //Your wanted image width 
                src.EndInit();
                return value;
            }
            catch (Exception e)
            {
                return null;
            }

            
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
