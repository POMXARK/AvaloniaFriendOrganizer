using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using ReactiveUI;



namespace FriendOrganizer.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public string Greeting => "Welcome to FriendOrganizer!";

        private IFriendDataService _friendDataService;

        public MainWindowViewModel(IFriendDataService friendDataService)
        {
            _friendDataService = friendDataService;
            CreateFriendList(friendDataService)
                .Connect()
                .Bind(out _availableFriends)
                .Subscribe(_ => Debug.WriteLine(" CreateFriendList"));
        }

        private readonly ReadOnlyObservableCollection<Friend> _availableFriends;

        public ReadOnlyObservableCollection<Friend> AvailableFriends => _availableFriends;

        private ISourceList<Friend> CreateFriendList(IFriendDataService friendDataService)
        {
            var friends = new SourceList<Friend>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }

        [Reactive] Friend SelectedFriend { get; set; }

    }
}

