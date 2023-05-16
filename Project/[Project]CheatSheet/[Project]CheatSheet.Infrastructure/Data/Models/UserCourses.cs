namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class UserCourses
    {
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}