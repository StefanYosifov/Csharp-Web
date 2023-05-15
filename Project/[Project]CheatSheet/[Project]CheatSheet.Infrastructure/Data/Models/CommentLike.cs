using System.ComponentModel.DataAnnotations.Schema;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class CommentLike : BaseEntity
    {
        public CommentLike()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Comment))] public Guid CommentId { get; set; }

        public Comment Comment { get; set; } = null!;
    }
}