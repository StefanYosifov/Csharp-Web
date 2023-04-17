namespace _Project_CheatSheet.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CommentLike
    {
        public CommentLike()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [ForeignKey(nameof(User))] 
        public string UserId { get; set; }

        [ForeignKey(nameof(Comment))]
        public Guid CommentId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Comment Comment { get; set; }=null!;
    }
}
