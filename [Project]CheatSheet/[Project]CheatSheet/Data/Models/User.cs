using Microsoft.AspNetCore.Identity;

namespace _Project_CheatSheet.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
        }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
