using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using ImTools;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Prism.Events;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
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
            Load();
            _eventAggregator.GetEvent<SendUpdateLoocupFriendEvent>().Subscribe(Updated);

            this.WhenAnyValue(x => x.SelectedFriend)
            .Subscribe(x => _eventAggregator.GetEvent<SendSelectedFriendEvent>().Publish(x));
        }


        [Reactive] public ObservableCollection<Friend> Friends { get; set; } = new();

        public void Updated(Friend updatedFriend)
        {
            for (int i = 0; i < Friends.Count; i++)
            {
                if (updatedFriend.Id == Friends[i].Id) {
                    Friends[i] =
                        new Friend
                        {
                            Id = updatedFriend.Id,
                            FirstName = updatedFriend.FirstName,
                            LastName = updatedFriend.LastName,
                            Email = updatedFriend.Email
                        };
                    SelectedFriend = updatedFriend;
                }
            }
        }

        public void Load() {
            var friends = _friendDataService.GetItems();
            Friends.Clear();
            foreach (var friend in friends) Friends.Add(friend);
        }

        [Reactive] public Friend SelectedFriend { get; set; }
    }
}

