using _Project_CheatSheet.Infrastructure.Data.Models.Base;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class Video:Entity
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string VideoUrl { get; set; }
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

    }
}
