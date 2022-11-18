using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase //, INavigationViewModel
    {
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IEventAggregator eventAggregator, IFriendDataService friendDataService) {
            _eventAggregator = eventAggregator;

            this.WhenAnyValue(x => x.SelectedFriend)
            .Subscribe(x => _eventAggregator.GetEvent<SendSelectedFriendEvent>().Publish(x));


            CreateFriendList(friendDataService)
            .Connect()
            .Bind(out _friends)
            .Subscribe();
        }

        public ISourceList<Friend> CreateFriendList(IFriendDataService friendDataService) {
            var friends = new SourceList<Friend>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }

        public readonly ReadOnlyObservableCollection<Friend> _friends;
        public ReadOnlyObservableCollection<Friend> Friends => _friends;


        [Reactive] public Friend SelectedFriend { get; set; }

    }
}

