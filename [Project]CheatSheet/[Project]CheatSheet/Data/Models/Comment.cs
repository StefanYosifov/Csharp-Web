namespace _Project_CheatSheet.Data.Models
{
    using _Project_CheatSheet;
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
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Resource))]
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; } = null!;

        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
