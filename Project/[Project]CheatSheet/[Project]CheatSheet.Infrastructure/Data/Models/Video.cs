using _Project_CheatSheet.Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class Video : Entity
    {
        public Video()
        {
            this.Topics = new HashSet<Topic>();
        }

        public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;

        [Required] public string VideoUrl { get; set; } = null!;

        public ICollection<Topic> Topics { get; set; }   
    }
}