namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TopicIssues
    {

        [ForeignKey(nameof(Topic))]
        public Guid TopicId { get; set; }

        public Topic Topic { get; set; }

        [ForeignKey(nameof(Issue))]
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
