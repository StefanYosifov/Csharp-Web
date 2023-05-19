using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Course;

namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseRespondAllModel
    {

        public string Id { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.TitleMaxLength, MinimumLength = CourseConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.DescriptionMaxLength, MinimumLength = CourseConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(CourseConstants.PriceMinRange, CourseConstants.PriceMaxRange)]
        public decimal Price { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        public string Category { get; set; } = null!;
        
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool HasPaid { get; set; }

        public int TopicsCount { get; set; }
    }
}
