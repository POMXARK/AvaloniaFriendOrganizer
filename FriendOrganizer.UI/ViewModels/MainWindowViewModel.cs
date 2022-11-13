using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System;
using System.Reactive.Linq;
using ReactiveUI;


namespace FriendOrganizer.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private IFriendDataService _friendDataService;

        public MainWindowViewModel(IFriendDataService friendDataService)
        {
            _friendDataService = friendDataService;
            CreateFriendList(friendDataService)
                .Connect()
                .Bind(out _friends)
                .Subscribe();
        }

        private ISourceList<Friend> CreateFriendList(IFriendDataService friendDataService)
        {
            var friends = new SourceList<Friend>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }

        // виртуальное поле для связывания
        [Reactive] Friend SelectedFriend { get; set; }


        private readonly ReadOnlyObservableCollection<Friend> _friends;
        public ReadOnlyObservableCollection<Friend> Friends => _friends;

    }
}

