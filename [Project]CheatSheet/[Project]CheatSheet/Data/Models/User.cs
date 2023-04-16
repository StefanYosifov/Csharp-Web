using Microsoft.AspNetCore.Identity;

namespace _Project_CheatSheet.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
            this.Likes = new HashSet<Like>();
            this.CommentLikes = new HashSet<CommentLike>();
            this.Comments = new HashSet<Comment>();
        }

        public DateTime CreatedOn { get; set; }

        public string? ProfilePictureUrl { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
    }
}
