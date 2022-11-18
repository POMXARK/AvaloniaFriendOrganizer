using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private static IFriendDataService _friendDataService;

        public NavigationViewModel(IEventAggregator eventAggregator, IFriendDataService friendDataService) {
            _eventAggregator = eventAggregator;
            _friendDataService = friendDataService;
            this.WhenAnyValue(x => x.SelectedFriend)
            .Subscribe(x => _eventAggregator.GetEvent<SendSelectedFriendEvent>().Publish(x));
        }

        public IEnumerable<Friend> Friends => _friendDataService.GetItems();

        [Reactive] public Friend SelectedFriend { get; set; }
    }
}

