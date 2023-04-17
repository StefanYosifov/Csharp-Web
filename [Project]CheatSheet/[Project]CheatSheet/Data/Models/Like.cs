namespace _Project_CheatSheet.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Like
    {
        public Like()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [ForeignKey(nameof(Resource))]
        public Guid ResourceId { get; set; }

        [ForeignKey(nameof(Comment))]
        public Guid? CommentId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
