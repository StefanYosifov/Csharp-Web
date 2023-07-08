namespace _Project_CheatSheet.Features.Issue
{
    using _Project_CheatSheet.Features.Issue.Models;
    using Common.Filters;
    using Common.Pagination;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("/issue")]
    public class IssueController:ApiController
    {
        private readonly IIssueService service;

        public IssueController(IIssueService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        [ActionFilter()]
        public async Task<ICollection<IssueRespondModel>> GetIssues([FromQuery]IssueQuery? query) 
            => await service.GetIssues(query);
    }
}
