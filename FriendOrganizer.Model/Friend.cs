
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FriendOrganizer.Model
{
    public class Friend : ReactiveObject
    {
        public int Id { get; set; }

        [Reactive] public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
