using _Project_CheatSheet.Features.Topics.Models;

namespace _Project_CheatSheet.Features.Topics.Interfaces
{
    public interface ITopicService
    {

        public Task<TopicRespondModel> GetTopic(int id);

        public Task<TopicDetailRespondModel> GetTopicDetail(int id);

    }
}
