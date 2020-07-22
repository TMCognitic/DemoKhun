using DemoKhun.ViewModels;
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
        private IDictionary<CreateEntityViewModel, CreateWindow> _createWindows;
        public App()
        {
            _createWindows = new Dictionary<CreateEntityViewModel, CreateWindow>();
            Messenger<PromptConfirmMessage>.Instance.Register(OnPromptMessageBoxMessage);
            Messenger<CreateEntityViewModel>.Instance.Register("Open", OnOpenCreateEntityViewModel);
            Messenger<CreateEntityViewModel>.Instance.Register("Close", OnCloseCreateEntityViewModel);
        }

        private void OnCloseCreateEntityViewModel(CreateEntityViewModel createViewModel)
        {
            if (_createWindows.ContainsKey(createViewModel))
            {
                _createWindows[createViewModel].Close();
                _createWindows.Remove(createViewModel);
            }
        }

        private void OnOpenCreateEntityViewModel(CreateEntityViewModel createViewModel)
        {
            if (_createWindows.Count < 3)
            {
                CreateWindow createWindow = new CreateWindow();
                createWindow.DataContext = createViewModel;                
                _createWindows.Add(createViewModel, createWindow);
                createWindow.Show();
            }
            else
            {
                MessageBox.Show("Trop de fenêtres de création sont ouvertes, veuillez terminer les créations existantes et recommencez!");
            }
        }

        private void OnPromptMessageBoxMessage(PromptConfirmMessage message)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(message.Message, message.Caption, MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                message.Result = true;
        }
    }
}
