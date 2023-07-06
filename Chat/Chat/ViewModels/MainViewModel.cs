using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using DevExpress.Mvvm;
using System.Windows.Controls;
using Chat.Services;
using Chat.Pages;

namespace Chat.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly PageService _pageService;

        public Page PageSource { get; set; }

        public MainViewModel(PageService pageService)
        {
            _pageService = pageService;


            _pageService.OnPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new ChatPage());

            
        }
    }
}
