using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModels
{
	public class FriendDetailViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private IFriendDataService _friendDataService;

        public FriendDetailViewModel(IEventAggregator eventAggregator, IFriendDataService friendDataService)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SendSelectedFriendEvent>().Subscribe(x => Friend = x); // accept the change

            _friendDataService = friendDataService;

        }

        public async void  SaveAddUpdate(Friend friend)
        {
            await _friendDataService.SaveAsync(friend);
            _eventAggregator.GetEvent<SendUpdateLoocupFriendEvent>().Publish(Friend);
        }

        [Reactive] public Friend Friend { get; set; }

    }
}