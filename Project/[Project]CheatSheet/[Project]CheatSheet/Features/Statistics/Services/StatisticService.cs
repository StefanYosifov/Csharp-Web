namespace _Project_CheatSheet.Features.Statistics.Services
{
    using _Project_CheatSheet.Common.Caching;
    using _Project_CheatSheet.Common.CachingConstants;
    using Infrastructure.Data;
    using Interfaces;
    using Microsoft.Extensions.Caching.Memory;
    using Models;

    public class StatisticService : IStatisticsService
    {
        private readonly IMemoryCache cache;
        private readonly ICacheService cacheService;
        private readonly CheatSheetDbContext context;
        public StatisticService(
            CheatSheetDbContext context,
            ICacheService cacheService,
            IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
            this.cacheService = cacheService;
        }

        public StatisticsModel GetAllStatistics()
        {
            var cacheKey = "home";
            if (cache.TryGetValue(cacheKey, out StatisticsModel statisticModel))
            {
                return statisticModel;
            }

            var newStatisticsModel = new StatisticsModel
            {
                ResourcesCount = context.Resources.Count(),
                UsersCount = context.Users.Count()
            };

            cacheService.SetCache(cacheKey, newStatisticsModel, CachingConstants.Course.HomeStatistics);
            return newStatisticsModel;
        }
    }
}