namespace _Project_CheatSheet.Features.Statistics
{
    using Common.Filters;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/statistics")]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService service;

        public StatisticsController(IStatisticsService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("all")]
        [ActionFilter("","",StatusCodes.Status403Forbidden)]
        public StatisticsModel GetAllStatistics()
        {
             return service.GetAllStatistics();
        }
    }
}