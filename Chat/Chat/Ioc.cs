using Chat.Services;
using Chat.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{

    public static class Ioc
    {
        private static readonly IServiceProvider _provider;

        static Ioc()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();
            services.AddTransient<ChatViewModel>();
            services.AddSingleton<PageService>();
          services.AddSingleton<ChatService>();

            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();
    }

    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => Ioc.Resolve<MainViewModel>();

        public ChatViewModel ChatViewModel => Ioc.Resolve<ChatViewModel>();
    }

}
