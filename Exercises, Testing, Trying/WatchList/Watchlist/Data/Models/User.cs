namespace Watchlist.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User:IdentityUser
    {
        public User()
        {
            this.UserMovies = new HashSet<UserMovie>();
        }

        public ICollection<UserMovie> UserMovies { get; set; }

    }
}
