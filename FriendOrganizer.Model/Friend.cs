
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FriendOrganizer.Model
{
    public class Friend : ReactiveObject
    {
        public uint Id { get; set; }

        [Reactive] public string? FirstName { get; set; }

        [Reactive] public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}
