using FriendOrganizer.Model;
using ReactiveUI.Fody.Helpers;
using Prism.Events;
using FriendOrganizer.UI.Event;

namespace FriendOrganizer.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;


        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SendSelectedFriendEvent>().Subscribe(x => Friend = x); // accept the change
        }

        [Reactive] public Friend Friend { get; set; }

    }
}

