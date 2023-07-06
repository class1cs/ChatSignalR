using Chat.Extenstions;
using Chat.Models;
using Chat.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Chat.Services
{
    public class ChatService
    {
        public async Task<HubConnection> ConnectToServer(string ip, int? port)
        {
            HubConnection connection = new HubConnectionBuilder()
              .WithUrl($"https://{ip}:{port}/chat")
              .Build();
            

            await connection.StartAsync();
            return connection;
        }

        public async Task SendMessage(TextMessage message, HubConnection connection)
        {
            if (connection?.State == HubConnectionState.Connected)
            {
                var newBaseMessage = new MessageBase()
                {
                    TextMessage = message,
                };
                await connection.InvokeAsync("Send", newBaseMessage);
            }
        }

        public async Task SendImage(string nick, Uri pic, BitmapImage image, HubConnection connection)
        {
            try
            {
                if (connection?.State == HubConnectionState.Connected)
                {
                    byte[] data;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }
                    var newBaseMessage = new MessageBase()
                    {
                        ImageMessage = new ImageMessage() { Username = nick, UserPic = pic, AddedImage = ImageUtils.BytesFromBitmap(image)  },
                    };
                    await connection.InvokeAsync("SendImage", newBaseMessage);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public async Task SendWritingMessage(string nick, HubConnection connection)
        {
            if (connection?.State == HubConnectionState.Connected)
            {
                
                await connection.InvokeAsync("OnWriting", nick);
            }
        }


        public async Task SendNotWritingMessage(string nick, HubConnection connection)
        {
            if (connection?.State == HubConnectionState.Connected)
            {

                await connection.InvokeAsync("OnNotWriting", nick);
            }
        }

        public async Task DisconnectFromServer(HubConnection connection, string nick, Uri pic)
        {
            if (connection?.State == HubConnectionState.Connected)
            {
                await connection.InvokeAsync("OnDisconnecting", nick, pic);
                await connection.StopAsync();
            }

        }
    }
}
