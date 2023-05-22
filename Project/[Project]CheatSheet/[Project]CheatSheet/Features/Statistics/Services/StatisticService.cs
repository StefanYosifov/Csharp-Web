namespace _Project_CheatSheet.Features.Statistics.Services
{
    using Infrastructure.Data;
    using Interfaces;
    using Models;

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