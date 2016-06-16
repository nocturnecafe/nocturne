using Nocturne.Common.Models;

namespace Web.Models
{
    public class UserIndexViewModel: ViewModelBase
    {
        public User[] Users { get; set; }
    }

    public class UserCreateEditDetailsViewModel : ViewModelBase
    {
        public User User { get; set; }
    }
}