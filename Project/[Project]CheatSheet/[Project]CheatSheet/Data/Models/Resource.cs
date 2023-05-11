using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _Project_CheatSheet.Data.Models.Base;
using _Project_CheatSheet.GlobalConstants.Resource;

namespace _Project_CheatSheet.Data.Models
{
    public class Resource : DeletableEntity
    {
        public Resource()
        {
            this.CategoryResources = new HashSet<CategoryResource>();
            this.ResourceLikes = new HashSet<ResourceLike>();
            this.Comments = new HashSet<Comment>();
            this.Id = Guid.NewGuid();
        }

        [Key] public Guid Id { get; set; }

        [MaxLength(ResourceConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ResourceConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [MaxLength(ResourceConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
        public ICollection<ResourceLike> ResourceLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}