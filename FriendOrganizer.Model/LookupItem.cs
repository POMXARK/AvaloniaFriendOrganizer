
using ReactiveUI.Fody.Helpers;

namespace FriendOrganizer.Model
{
    public class LookupItem
    {
        public uint Id { get; set; }

        [Reactive] public string? DisplayMember { get; set; }
    }
}
