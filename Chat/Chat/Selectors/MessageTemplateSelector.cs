using Chat.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chat.Selectors
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MessageTemplate { get; set; }
        public DataTemplate DeclarationTemplate { get; set; }

        public DataTemplate ImageMessageTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MessageBase message = (MessageBase)item;

            if (message.TextMessage != null)
            {
                return MessageTemplate;
            }
            else if (message.DeclarationMessage != null)
            {
                return DeclarationTemplate;
            }
            else if (message.ImageMessage != null)
            {
                return ImageMessageTemplate;
            }
            return null;
            
        }
    }
}
