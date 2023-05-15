using System.ComponentModel.DataAnnotations.Schema;

namespace _Project_CheatSheet.Data.Models
{
    public class UserCourses
    {
        public string UserId { get; set; }
        public User User{ get; set; }
        public Guid CourseId{ get; set; }
        public Course Course{ get; set; }

    }
}
