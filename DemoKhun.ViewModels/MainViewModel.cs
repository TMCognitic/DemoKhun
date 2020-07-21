using DemoKhun.Models.Client.Entities;
using DemoKhun.Models.Client.Repositories;
using DemoKhun.Models.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Tools.MVVM.ViewModels;
using Tools.Patterns.Mediator;

namespace DemoKhun.ViewModels
{
    public class MainViewModel : CollectionViewModelBase<EntityViewModel>
    {
        private IEntityRepository<Entity> _entityRepository;

        public MainViewModel()
        {
            _entityRepository = new EntityRepository();
            Messenger<EntityViewModel>.Instance.Register("Delete", OnDeleteEntityViewModel);
        }

        private void OnDeleteEntityViewModel(EntityViewModel entityViewModel)
        {
            Items.Remove(entityViewModel);
        }

        protected override ObservableCollection<EntityViewModel> LoadItems()
        {
            return new ObservableCollection<EntityViewModel>(_entityRepository.Get().Select(e => new EntityViewModel(e)));
        }
    }
}
