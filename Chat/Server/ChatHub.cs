using ChatModels;
using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore.Storage;
using Chat.Models;
using System.Windows.Markup;
using Chat.Extenstions;
using DevExpress.Mvvm.Native;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LiteDB;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;
using Owin;

namespace Server
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {

       
        public static ObservableCollection<User> Nicks = new();

        private static LiteDatabase _db;

        private static ILiteCollection<MessageBase> Messages;


        public async Task Send(MessageBase messageBase)
        {
            if (messageBase.TextMessage.Data.Length > 500)
            {
                await Clients.Caller.SendAsync("LengthError", "Длина сообщения не может быть более 500 символов!");
                return;
            }
            
            await Clients.All.SendAsync("Receive", messageBase.TextMessage);
            using (_db = new LiteDatabase(@"ChatDB.db"))
            {
                Messages = _db.GetCollection<MessageBase>("messages");
                Messages.Insert(messageBase);
            }
        }

        public async Task SendImage(MessageBase messageBase)
        {
            try
            {
                await Clients.All.SendAsync("ReceivePic", messageBase.ImageMessage);
                using (_db = new LiteDatabase(@"ChatDB.db"))
                {
                    Messages = _db.GetCollection<MessageBase>("messages");
                    Messages.Insert(messageBase);
                }
               
            }
            catch
            {
                return;
            }

        }



        public async  Task OnConnecting(string username, Uri pic)
        {
            try
            {
                
                if (Nicks.Any(x => x.Nick == username))
                {
                    await Clients.Caller.SendAsync("NickError", "Ник занят!");                    
                    return;
                }
                Nicks.Add(new User { Nick = username, Pic = pic });

 
                
                using (_db = new LiteDatabase(@"ChatDB.db"))
                {
                    Messages = _db.GetCollection<MessageBase>("messages");
                    Messages.Insert(new MessageBase { DeclarationMessage = new DeclarationMessage { Declaration = $"Пользователь {username} пришел в наш чат" } });
               
                await Clients.Others.SendAsync("NewConnection", $"Пользователь {username} пришел в наш чат", Nicks);
                await Clients.Caller.SendAsync("History", Messages.FindAll().ToList(), Nicks);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public async Task OnDisconnecting(string username, Uri pic)
        {
            Nicks.Remove(Nicks.FirstOrDefault(x => x.Nick == username && x.Pic == pic));

            await Clients.Others.SendAsync("NewDisconnection", $"Пользователь {username} вышел из нашего чата", Nicks);
            using (_db = new LiteDatabase(@"ChatDB.db"))
            {
                Messages = _db.GetCollection<MessageBase>("messages");
                Messages.Insert(new MessageBase { DeclarationMessage = new DeclarationMessage { Declaration = $"Пользователь {username} вышел из нашего чата!" } });
            }
        }

        public async Task OnWriting(string username)
        {
            User user = Nicks.FirstOrDefault(x => x.Nick == username);
            user.IsWriting = true;
            await Clients.All.SendAsync("WritingMessage", $"Печатает", Nicks);
            
        }

      

        public async Task OnNotWriting(string username)
        {
            User user = Nicks.FirstOrDefault(x => x.Nick == username);
            user.IsWriting = false;
            await Clients.All.SendAsync("NotWritingMessage", $"Не Печатает", Nicks);

        }
    }
}
