using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Course;
using _Project_CheatSheet.Infrastructure.Data.Models.Base;
using _Project_CheatSheet.Infrastructure.Data.Models.Enums;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class Course : Entity
    {
        public Course()
        {
            Topics = new HashSet<Topic>();
            UsersCourses = new HashSet<UserCourses>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(CourseConstants.TitleMaxLength)]

        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(CourseConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(CourseConstants.PriceMinRange, CourseConstants.PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public CourseCategoryEnum Category { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<UserCourses> UsersCourses { get; set; }
    }
}