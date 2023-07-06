using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows;
using Chat.Extenstions;

namespace Chat.Converters
{
    public class ImageWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = ImageUtils.ImageFromBuffer((byte[])value);
            int width = (int)image.PixelWidth;
            if (width > 400)
            {
                width = 300;
                return width;
            }
            return width;

        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
