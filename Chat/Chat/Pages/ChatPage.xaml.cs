using Chat.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        public ChatPage()
        {
            InitializeComponent();
          
            ((INotifyCollectionChanged)messages.ItemsSource).CollectionChanged +=
     new NotifyCollectionChangedEventHandler(List1CollectionChanged);
        }

        

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        TextBox t = sender as TextBox;
                        t.Text += Environment.NewLine;
                        t.CaretIndex = t.Text.Length - 1;
                        break;
                }
            }
            else
            {
                if (e.Key == Key.Enter)
                {
                    var viewModel = (ChatViewModel)DataContext;
                    if (viewModel.SendMessageCommand.CanExecute(null))
                        viewModel.SendMessageCommand.Execute(null);
                    e.Handled = true;
                }
            }
        }

        public void List1CollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            Scroller.ScrollToEnd();
        }

     
    }
}
