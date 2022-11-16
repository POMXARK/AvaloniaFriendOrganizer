using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using Prism.Regions;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IEventAggregator _eventAggregator;

        public string Test => "NavigationViewModel";

        public NavigationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MessageSendEvent>().Subscribe(GetFriend);
        }

        private void GetFriend(Friend obj)
        {
            Friend = obj;
        }

        [Reactive] public Friend Friend { get; set; }

    }

}

