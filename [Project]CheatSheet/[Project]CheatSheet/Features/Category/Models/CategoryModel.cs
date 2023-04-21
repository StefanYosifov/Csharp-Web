namespace _Project_CheatSheet.Controllers.Category.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryModel
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

    }
}
