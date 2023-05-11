using System.ComponentModel.DataAnnotations.Schema;

namespace _Project_CheatSheet.Data.Models
{
    public class CategoryResource
    {
        [ForeignKey(nameof(Category))] public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(Resource))] public Guid ResourceId { get; set; }

        public virtual Resource Resource { get; set; } = null!;
    }
}