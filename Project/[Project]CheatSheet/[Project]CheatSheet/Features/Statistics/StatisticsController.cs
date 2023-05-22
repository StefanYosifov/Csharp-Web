namespace _Project_CheatSheet.Features.Statistics
{
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetAllStatistics()
        {
            var statistics = service.GetAllStatistics();
            if (statistics == null)
            {
                return Forbid();
            }

            return Ok(statistics);
        }
    }
}