using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tools.Patterns.Mediator;

namespace DemoKhun
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Messenger<PromptConfirmMessage>.Instance.Register(OnPromptMessageBoxMessage);
        }

        private void OnPromptMessageBoxMessage(PromptConfirmMessage message)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(message.Message, message.Caption, MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                message.Result = true;
        }
    }
}
