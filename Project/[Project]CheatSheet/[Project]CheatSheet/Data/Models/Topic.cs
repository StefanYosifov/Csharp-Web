using System.ComponentModel.DataAnnotations.Schema;
using _Project_CheatSheet.Data.Models.Base;

namespace _Project_CheatSheet.Data.Models
{
    public class Topic:Entity
    {
        public Topic()
        {
            Videos = new HashSet<Video>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }

        public Course Course { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
