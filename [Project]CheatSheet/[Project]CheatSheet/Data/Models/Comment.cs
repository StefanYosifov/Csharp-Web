namespace _Project_CheatSheet.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment:BaseEntity
    {
        public Comment()
        {
            this.CommentLikes = new HashSet<CommentLike>();
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ModelConstants.CommentsMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public string UserName { get; set; }

        public string UserProfileImage { get; set; }

        [ForeignKey(nameof(Resource))]
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
