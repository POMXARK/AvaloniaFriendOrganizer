using FriendOrganizer.Model;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModels
{
    public interface INavigationViewModel
    {
        Friend SelectedFriend { get; set; }
    }
}