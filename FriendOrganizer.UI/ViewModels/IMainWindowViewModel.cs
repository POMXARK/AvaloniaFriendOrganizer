using DynamicData;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModels
{
    public interface IMainWindowViewModel
    {
        Friend Friend { get; set; }
    }
}