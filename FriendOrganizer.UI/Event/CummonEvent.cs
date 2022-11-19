using FriendOrganizer.Model;
using Prism.Events;

namespace FriendOrganizer.UI.Event
{
    public class SendSelectedFriendEvent : PubSubEvent<Friend>{}
    public class SendUpdateLoocupFriendEvent : PubSubEvent<Friend>{}
}
