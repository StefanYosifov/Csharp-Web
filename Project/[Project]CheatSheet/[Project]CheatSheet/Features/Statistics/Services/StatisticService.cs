using _Project_CheatSheet.Features.Statistics.Interfaces;
using _Project_CheatSheet.Features.Statistics.Models;
using _Project_CheatSheet.Infrastructure.Data;

namespace _Project_CheatSheet.Features.Statistics.Services
{
    public class StatisticService : IStatisticsService
    {
        private readonly CheatSheetDbContext context;

        public StatisticService(CheatSheetDbContext context)
        {
            this.context = context;
        }

        public StatisticsModel GetAllStatistics()
        {
            return new StatisticsModel
            {
                ResourcesCount = context.Resources.Count(),
                UsersCount = context.Users.Count()
            };
        }
    }
}