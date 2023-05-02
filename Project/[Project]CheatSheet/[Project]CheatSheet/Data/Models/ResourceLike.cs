namespace _Project_CheatSheet.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ResourceLike : BaseEntity
    {
        public ResourceLike()
        {

            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Resource))]
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}
