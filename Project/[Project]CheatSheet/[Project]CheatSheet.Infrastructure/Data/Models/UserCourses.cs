using System.ComponentModel.DataAnnotations;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class UserCourses
    {
        [Required]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        [Required]
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}