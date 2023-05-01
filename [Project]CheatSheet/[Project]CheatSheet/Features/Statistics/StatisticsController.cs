namespace _Project_CheatSheet.Features.Statistics
{
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Features.Statistics.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class StatisticsController:ApiController
    {
        private readonly IStatisticsService service;

        public StatisticsController(IStatisticsService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        [Route("/statistics/all")]
        public async Task<ActionResult> GetAllStatistics()
        {
            var statistics = service.GetAllStatistics();
            if(statistics == null)
            {
                return Forbid();
            }
            return Ok(statistics);
        }
    }
}
