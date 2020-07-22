using DemoKhun.Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.MVVM.Commands;
using Tools.MVVM.ViewModels;
using Tools.Patterns.Mediator;

namespace DemoKhun.ViewModels
{
    public class EntityViewModel : EntityViewModelBase<Entity>
    {
        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new Command(Delete));
            }
        }   
        
        public string Text
        {
            get { return Entity.Text; }
        }

        public EntityViewModel(Entity entity) : base(entity)
        {
        }

        private void Delete()
        {
            PromptConfirmMessage promptConfirmMessage = new PromptConfirmMessage("Are you sure?", "Delete");
            Messenger<PromptConfirmMessage>.Instance.Send(promptConfirmMessage);
            if(promptConfirmMessage.Result)
            {
                //Appel du service pour suppression 

                //Ensuite
                Messenger<EntityViewModel>.Instance.Send("Delete", this);
            }
        }


    }
}
