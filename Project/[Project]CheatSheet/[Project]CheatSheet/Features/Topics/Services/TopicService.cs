using _Project_CheatSheet.Features.Topics.Interfaces;
using _Project_CheatSheet.Features.Topics.Models;
using _Project_CheatSheet.Infrastructure.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Features.Topics.Services
{
    public class TopicService : ITopicService
    {
        private readonly CheatSheetDbContext context;
        private readonly IMapper mapper;

        public TopicService(
            CheatSheetDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TopicRespondModel> GetTopic(string id)
        {
            var topic = await context.Topics.Include(t => t.Video).FirstOrDefaultAsync(t => t.Id.ToString() == id);
            return mapper.Map<TopicRespondModel>(topic);
        }

        public async Task<TopicDetailRespondModel> GetTopicDetail(string id)
        {
            return await
                context.Topics.ProjectTo<TopicDetailRespondModel>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(t => t.Id.ToString() == id);
        }

        public async Task<IEnumerable<TopicRespondModel>> GetAllTopics(string id)
        {
            return await context.Topics.Where(t => t.CourseId.ToString() == id.ToLower())
                .ProjectTo<TopicRespondModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}