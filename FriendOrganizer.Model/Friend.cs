
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FriendOrganizer.Model
{
    public class Friend : ReactiveObject
    {
        public uint Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}
