using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        private ILookupDataService _friendLookupService;

        public NavigationViewModel(ILookupDataService friendLookupService)
        {
            _friendLookupService = friendLookupService;
            CreateFriendList(_friendLookupService)
                .Connect()
                .Bind(out _friends)
                .Subscribe();
        }

        private ISourceList<LookupItem> CreateFriendList(ILookupDataService friendDataService)
        {
            var friends = new SourceList<LookupItem>();
            friends.AddRange(friendDataService.GetItems());
            return friends;
        }


        private readonly ReadOnlyObservableCollection<LookupItem> _friends;

        public ReadOnlyObservableCollection<LookupItem> Friends => _friends;

    }
}
