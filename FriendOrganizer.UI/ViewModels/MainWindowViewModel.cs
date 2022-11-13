using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public string Greeting => "Welcome to FriendOrganizer!";

        private IFriendDataService _friendDataService;

        public MainWindowViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }

        public void Load()
        {
            var friends = _friendDataService.GetAll();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        public ObservableCollection<Friend> Friends { get; set; }

        [Reactive] Friend SelectedFriend { get; set; }

    }
}

