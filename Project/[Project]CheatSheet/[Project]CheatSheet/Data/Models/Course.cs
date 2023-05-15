using _Project_CheatSheet.Data.Models.Base;
using _Project_CheatSheet.Data.Models.Base.Interfaces;
using _Project_CheatSheet.Data.Models.Enums;

namespace _Project_CheatSheet.Data.Models
{
    public class Course : Entity
    {
        public Course()
        {
            this.Topics = new HashSet<Topic>();
            this.UsersCourses=new HashSet<UserCourses>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public CourseCategoryEnum Category { get; set; }

        public ICollection<Topic> Topics{ get; set; }

        public ICollection<UserCourses> UsersCourses { get; set; }

    }
}
