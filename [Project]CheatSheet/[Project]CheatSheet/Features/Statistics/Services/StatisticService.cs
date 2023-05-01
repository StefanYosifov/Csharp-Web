namespace _Project_CheatSheet.Features.Statistics.Services
{
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Features.Statistics.Interfaces;
    using _Project_CheatSheet.Features.Statistics.Models;
    using System.Threading.Tasks;

    public class StatisticService : IStatisticsService
    {
        private readonly CheatSheetDbContext context;

        public StatisticService(CheatSheetDbContext context)
        {
            this.context = context;
        }

        public StatisticsModel GetAllStatistics()
        {
            return new StatisticsModel()
            {
                ResourcesCount = context.Resources.Count(),
                UsersCount = context.Users.Count()
            };

        }
    }
}
