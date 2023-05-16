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

        public async Task<TopicRespondModel> GetTopic(int id)
        {
            return await
                context.Topics.ProjectTo<TopicRespondModel>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TopicDetailRespondModel> GetTopicDetail(int id)
        {
            return await
                context.Topics.ProjectTo<TopicDetailRespondModel>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}