using FriendOrganizer.Model;
using FriendOrganizer.UI.Event;
using Prism.Events;
using ReactiveUI.Fody.Helpers;

namespace FriendOrganizer.UI.ViewModels
{
	public class FriendDetailViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;


        public FriendDetailViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SendSelectedFriendEvent>().Subscribe(x => Friend = x); // accept the change
        }

        [Reactive] public Friend Friend { get; set; }
    }
}