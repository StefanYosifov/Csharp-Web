using _Project_CheatSheet.Infrastructure.Data.Models;

namespace _Project_CheatSheet.Features.Topics.Models
{
    public class TopicRespondModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string CourseName { get; set; }
        public ICollection<Video> Videos { get; set; } //Todo change videos type later
    }
}
