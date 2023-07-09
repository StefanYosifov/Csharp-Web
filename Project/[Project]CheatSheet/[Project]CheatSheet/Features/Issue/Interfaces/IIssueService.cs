namespace _Project_CheatSheet.Features.Issue.Interfaces
{
    using _Project_CheatSheet.Common.Pagination;
    using Infrastructure.Data.Models;
    using Models;

    public interface IIssueService
    {
        public Task<ICollection<IssueRespondModel>> GetIssues(IssueQuery? query);

        //Maybe admin logic
        public Task<string> WithdrawIssue(string issueId);

        public Task<ICollection<IssueRespondModel>> GetIssuesByTopicId(string topicId);

        public Task<string> CreateIssue(IssueRequestModel issue);

    }
}
