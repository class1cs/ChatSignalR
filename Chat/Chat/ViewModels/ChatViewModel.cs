using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Chat.Models;
using System.Windows.Input;
using System.Windows;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using ChatModels;
using Chat.Services;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using Chat.Extenstions;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Documents;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using LiteDB;

namespace Chat.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {

        public HubConnection connection;

        public BitmapImage LoadedImage;
        public bool IsCanChangeNick { get; set; } = true;

        public string Message { get; set; }

        public MessageBase SentMessage { get; set; }
        public bool IsSettingsOpen { get; set; }

        private bool _isWriting;

        public ObservableCollection<MessageBase> Messages { get; set; } = new();

        public ObservableCollection<User> Nicks { get; set; } = new();

        private readonly ChatService _chatService;

        public ImageSource ShowedImage;

        public ConnectionData ConnectionData { get; set; } 

        public async Task DisableFunctionality()
        {

                IsCanChangeNick = true;
                Nicks.Clear();
                Messages.Clear();

        }






        public void UnsubscribeFromEvents()
        {
            connection.Remove("NickError");
            connection.Remove("Receive");
            connection.Remove("LengthError");
            connection.Remove("SentNotification");
            connection.Remove("NewConnection");
            connection.Remove("WritingMessage");
            connection.Remove("NotWritingMessage");
            connection.Remove("NewDisconnection");
            connection.Remove("ReceivePic");
            connection.Remove("SentImageNotification");
        }

        public static void Save(BitmapImage image, string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var fileMode = fileInfo.Exists ? FileMode.Truncate : FileMode.CreateNew;
            using (FileStream fs = File.Open(filePath, fileMode, FileAccess.Write, FileShare.None))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            
                encoder.Save(fs);
            }
            
        }

        public static (int,int) ScaleImage(ImageSource image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            return (newWidth, newHeight);
        }

        public void InitEvents()
        {
            
            connection.On<List<MessageBase>, ObservableCollection<User>>("History", async (messages, users) =>
            {
                try
                {
                    await App.Current.Dispatcher.InvokeAsync(() =>
                    {
                        foreach (var obj in messages)
                        {
                            Messages.Add(obj);
                        }



                        Nicks = users;
                    });
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                 
                
            });

            

            connection.On<string>("NickError", async (message) =>
            {
                await connection.StopAsync();
                IsCanChangeNick = true;
                MessageBox.Show(message);


            });

            connection?.On<TextMessage>("Receive", async (message) =>
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    Messages.Add(new MessageBase { TextMessage = message  });

                });


            });

            connection?.On<ImageMessage>("ReceivePic", async (msg) =>
            {
                try
                {
                    await App.Current.Dispatcher.InvokeAsync(() =>
                    {
                        Messages.Add(new MessageBase { ImageMessage =msg });

                    });
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
              


            });

           

            connection.Closed += async (error) =>
            {
                try
                {

                    App.Current.Dispatcher.Invoke(() =>
                    {
                        IsCanChangeNick = true;
                        Nicks.Clear();
                        Messages.Clear();
                    });
                    if (error == null)
                    {
                        return;
                    }
                    if (connection?.State == HubConnectionState.Connected)
                    {
                        await connection.InvokeAsync("OnDisconnecting", ConnectionData.Nick);
                        await connection.StopAsync();
                    }
                    MessageBox.Show($"Сервер перестал отвечать. ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show(error.ToString());

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            };


            

           

            connection.On<string, ObservableCollection<User>>("NewConnection", async (declaration, listclient) =>
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    Messages.Add(new MessageBase() { DeclarationMessage = new DeclarationMessage { Declaration = declaration } });
                    Nicks = listclient;
                });
            });

            connection.On<string, ObservableCollection<User>>("WritingMessage", async (message, listclient) =>
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    Nicks = listclient;
                });
            });

            connection.On<string, ObservableCollection<User>>("NotWritingMessage", async (message, listclient) =>
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {

                    Nicks = listclient;
                });


            });

            connection.On<string, ObservableCollection<User>>("NewDisconnection", async (declaration, listclient) =>
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    Messages.Add(new MessageBase() { DeclarationMessage = new DeclarationMessage { Declaration = declaration } });
                    Nicks = listclient;
                });


            });

           

        }
        
        
        public ChatViewModel(ChatService chatService)
        {

            App.Current.MainWindow.Closing += async (s, e) =>
            {
                await _chatService.DisconnectFromServer(connection, ConnectionData.Nick, ConnectionData.UserPic);
            };
            
            _chatService = chatService;
           
            if (!File.Exists("ConnectionData.json"))
            {
                File.Create("ConnectionData.json");
                if (string.IsNullOrEmpty(File.ReadAllText("ConnectionData.json")))
                {
                    File.WriteAllText("ConnectionData.json", JsonConvert.SerializeObject(
                    new ConnectionData
                    {
                        IP = "127.0.0.1",
                        Port = 2222,
                        Nick = "Прикольный парень",
                        UserPic = new Uri("about:blank")
                    })
                );
                }
                ConnectionData = JsonConvert.DeserializeObject<ConnectionData>(File.ReadAllText("ConnectionData.json"));
                return;
            }
            ConnectionData = JsonConvert.DeserializeObject<ConnectionData>(File.ReadAllText("ConnectionData.json"));

          

            


        }

        public ICommand ConnectToServerCommand => new AsyncCommand(async () =>
        {
            try
            {
                
                connection = await _chatService.ConnectToServer(ConnectionData.IP, ConnectionData.Port);
               

                if (connection?.State == HubConnectionState.Connected || connection?.State == HubConnectionState.Reconnecting)
                {
                    InitEvents();
                    IsCanChangeNick = false;

                    await connection.InvokeAsync("OnConnecting", ConnectionData.Nick, ConnectionData.UserPic);
                   
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        App.Current.MainWindow.Title = $"Чат - {ConnectionData.Nick}";

                    });
                }

            }
           
            catch(HttpRequestException e)
            {
                await DisableFunctionality();
                MessageBox.Show($"Невозможно подключиться к серверу. Сервер ответил {e.StatusCode} и {e.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            

        }, () => !string.IsNullOrWhiteSpace(ConnectionData.Nick) && ConnectionData.Port != null && !string.IsNullOrWhiteSpace(ConnectionData.IP) && connection?.State != HubConnectionState.Connected && connection?.State != HubConnectionState.Connecting);

        public ICommand ShowSettings => new DelegateCommand<string>(async (nick) =>
        {

            IsSettingsOpen = true;
            
         
        }, (_) => connection?.State != HubConnectionState.Connected && connection?.State != HubConnectionState.Connecting);

        

        public ICommand ShowImageCommand => new DelegateCommand<System.Windows.Media.ImageSource>(async (img) =>
        {
            if (MaterialDesignThemes.Wpf.DialogHost.IsDialogOpen("ViewerWindow"))
            {
                MaterialDesignThemes.Wpf.DialogHost.Close("ViewerWindow");
            }
           
            double width = (img as BitmapSource).PixelWidth;

            double height = (img as BitmapSource).PixelHeight;

            var imageContent = new CachedImage.Image
            {
                Source = img,
                Width = width,
             
                Height = height
            };
            RenderOptions.SetBitmapScalingMode(imageContent, BitmapScalingMode.Fant);

            if (width > 1024)
            {
                var newSize = ScaleImage(img, 1000, 650);
                imageContent = new CachedImage.Image
                {
                    Source = img,
                    Width = newSize.Item1,
                    Height = newSize.Item2
                   

                };
                RenderOptions.SetBitmapScalingMode(imageContent, BitmapScalingMode.Fant);
            }
            if (height > 768)
            {
                var newSize = ScaleImage(img, 1000, 650);
                imageContent = new CachedImage.Image
                {
                    Source = img,
                    Width = newSize.Item1,
                    Height = newSize.Item2


                };
                RenderOptions.SetBitmapScalingMode(imageContent, BitmapScalingMode.Fant);
            }
           
           
            
            await MaterialDesignThemes.Wpf.DialogHost.Show(imageContent, "ViewerWindow");


        });

        public ICommand DownloadImageCommand => new DelegateCommand<MessageBase>(async (msg) =>
        {
            try
            {
                ImageMessage imageMessage = msg.ImageMessage;
                SaveFileDialog dlg = new SaveFileDialog();

                string name = $"Pic-{DateTime.Now.ToString("HH_mm_ss", new CultureInfo("ru-RU"))}";
                dlg.FileName = name;
                dlg.DefaultExt = ".png";
                bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    Save(ImageUtils.ImageFromBuffer(imageMessage.AddedImage), dlg.FileName);

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        });


        public ICommand SendWritingCommand => new DelegateCommand(async () =>
        {

            if (!string.IsNullOrEmpty(Message) && _isWriting == false)
            {
                _isWriting = true;
                await _chatService.SendWritingMessage(ConnectionData.Nick, connection);
            }
            if(string.IsNullOrEmpty(Message))
            { 
                _isWriting = false;
                await _chatService.SendNotWritingMessage(ConnectionData.Nick, connection);
            }
            

        });


        public ICommand ClosePhotoViewCommand => new DelegateCommand(async () =>
        {
            if (MaterialDesignThemes.Wpf.DialogHost.IsDialogOpen("ViewerWindow"))
            {
                MaterialDesignThemes.Wpf.DialogHost.Close("ViewerWindow");
            }

        });

        public ICommand SaveSettings => new AsyncCommand(async () =>
        {
            
            await File.WriteAllTextAsync("ConnectionData.json", JsonConvert.SerializeObject(ConnectionData));
            IsSettingsOpen = false;

        });

        

        public ICommand SendImageCommand => new AsyncCommand(async () =>
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";



                if (op.ShowDialog() == true)
                {
                    LoadedImage = new BitmapImage(new Uri(op.FileName));
                    await _chatService.SendImage(ConnectionData.Nick, ConnectionData.UserPic, LoadedImage, connection);
                    
                }

                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
           
           
        }, () => connection != null && connection?.State != HubConnectionState.Disconnected && connection?.State != HubConnectionState.Connecting);

        public ICommand DisconnectFromServerCommand => new AsyncCommand(async () =>
        {
            UnsubscribeFromEvents();
            await _chatService.DisconnectFromServer(connection, ConnectionData.Nick, ConnectionData.UserPic);

            await DisableFunctionality();

        }, () => connection?.State != HubConnectionState.Disconnected && connection?.State != HubConnectionState.Reconnecting && connection != null);
        public ICommand SendMessageCommand => new AsyncCommand(async () =>
        {
            try
            {
               
                await _chatService.SendMessage(new TextMessage { Username = ConnectionData.Nick, Data = Message, UserPic = ConnectionData.UserPic }, connection);
                Message = string.Empty;
                await Task.Delay(1000);
            }
            catch
            {
                if (connection?.State == HubConnectionState.Connected)
                {
                    await _chatService.DisconnectFromServer(connection, ConnectionData.Nick, ConnectionData.UserPic);
                }
                throw;
            }
        }, () =>  !string.IsNullOrWhiteSpace(Message) && connection != null && connection?.State != HubConnectionState.Disconnected && connection?.State != HubConnectionState.Connecting);
    }
}
