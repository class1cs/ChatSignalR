using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chat.Extenstions
{
  
        public static class ImageUtils
        {
            public static BitmapImage ImageFromBuffer( this Byte[] bytes)
            {
                MemoryStream stream = new MemoryStream(bytes);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
            

            public static byte[] BytesFromBitmap(this BitmapImage image)
            {
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                    return data;
                }

             }



            public static BitmapImage ToBitmapImage(BitmapSource bitmapSource)
            {
               

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                MemoryStream memoryStream = new MemoryStream();
                BitmapImage bImg = new BitmapImage();

                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(memoryStream);

                memoryStream.Position = 0;
                bImg.BeginInit();
                bImg.StreamSource = memoryStream;
                bImg.EndInit();

                memoryStream.Close();

                return bImg;
            }
            public static ImageSource ToImageSource(System.Drawing.Image image)
            {
                BitmapImage bitmap = new BitmapImage();

                using (MemoryStream stream = new MemoryStream())
                {
                    // Save to the stream
                    image.Save(stream, ImageFormat.Png);

                    // Rewind the stream
                    stream.Seek(0, SeekOrigin.Begin);

                    // Tell the WPF BitmapImage to use this stream
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                }

                return bitmap;
            }
        }
    
}
