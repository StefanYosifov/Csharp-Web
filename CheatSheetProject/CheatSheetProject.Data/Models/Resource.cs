namespace CheatSheetProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resource
    {
        public Resource()
        {
            this.Id = Guid.NewGuid();
            this.CategoryResources = new HashSet<CategoryResource>();
        }
        public Guid Id { get; set; }

        [MaxLength(ModelConstants.ResourceTitleMaxLength)]
        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [MaxLength(ModelConstants.ResourceContentMaxLength)]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<CategoryResource> CategoryResources { get; set; } 
    }
}
