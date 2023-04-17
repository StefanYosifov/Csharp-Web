namespace _Project_CheatSheet.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {

        public Comment()
        {
            this.Likes = new HashSet<Like>();
            this.CommentLikes = new HashSet<CommentLike>();

            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [StringLength(ModelConstants.CommentsMaxLength,MinimumLength =ModelConstants.CommentsMinLength)]
        public string Content { get; set; } =null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [ForeignKey(nameof(Resource))]
        public Guid ResourceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }

        public virtual User User { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
    }
}
