using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData.Binding;


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
                .Bind(out _friends)
                .Subscribe();

            _friendDataService = friendDataService;
            CreateItemFriendList(friendDataService)
                .Connect()
                .Transform(x => new LookupItem { DisplayMember = x.FirstName + " " + x.LastName })
                .Bind(out _Itemfriends)
                .Subscribe();
        }

        private readonly ReadOnlyObservableCollection<Friend> _friends;

        public ReadOnlyObservableCollection<Friend> Friends => _friends;


        private readonly ReadOnlyObservableCollection<LookupItem> _Itemfriends;

        public ReadOnlyObservableCollection<LookupItem> ItemFriends => _Itemfriends;

        private ISourceList<Friend> CreateFriendList(IFriendDataService friendDataService)
        {
            var friends = new SourceList<Friend>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }

        private ISourceList<Friend> CreateItemFriendList(IFriendDataService friendDataService)
        {
            var friends = new SourceList<Friend>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }

        // виртуальное поле для связывания
        [Reactive] Friend SelectedFriend { get; set; }

    }
}

