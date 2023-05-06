using Microsoft.AspNetCore.Identity;

namespace _Project_CheatSheet.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
            this.ResourceLikes = new HashSet<ResourceLike>();
            this.CommentLikes = new HashSet<CommentLike>();
            this.Comments = new HashSet<Comment>();
        }
         
        public DateTime CreatedOn { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string ProfileDescription { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<ResourceLike> ResourceLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
