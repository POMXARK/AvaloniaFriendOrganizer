using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System;
using System.Reactive.Linq;
using ReactiveUI;
using Prism.Events;
using FriendOrganizer.UI.Event;

namespace FriendOrganizer.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public IFriendDataService _friendDataService;
        private IEventAggregator _eventAggregator;

        public MainWindowViewModel(
            IFriendDataService friendDataService,
            //IRegionManager regionManager,
            IEventAggregator eventAggregator
            )
        {
            _friendDataService = friendDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MessageSendEvent>().Publish(SelectedFriend);
            CreateFriendList(friendDataService)
                .Connect()
                .Bind(out _friends)
                .Subscribe();
        }

        public ISourceList<Friend> CreateFriendList(IFriendDataService friendDataService)
        {
            var friends = new SourceList<Friend>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }

        public readonly ReadOnlyObservableCollection<Friend> _friends;
        public ReadOnlyObservableCollection<Friend> Friends => _friends;

        [Reactive] public Friend SelectedFriend { get; set; }
    }
}

