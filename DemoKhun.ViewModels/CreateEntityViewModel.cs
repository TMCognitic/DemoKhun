using DemoKhun.Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.MVVM.Commands;
using Tools.MVVM.ViewModels;
using Tools.Patterns.Mediator;

namespace DemoKhun.ViewModels
{
    public class CreateEntityViewModel : ViewModelBase
    {
        private string _text;
        private ICommand _saveCommand;

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                Set(ref _text , value);
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(Save, () => !string.IsNullOrWhiteSpace(Text)));
            }
        }

        private void Save()
        {
            Entity entity = new Entity(Text);
            //Appel du service pour Ajout

            //Ensuite
            Messenger<CreateEntityViewModel>.Instance.Send("Close", this);
            Messenger<EntityViewModel>.Instance.Send("Add", new EntityViewModel(entity));
        }
    }
}
