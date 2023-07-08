namespace _Project_CheatSheet.Features.Issue.Services;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Exceptions;
using Common.Pagination;
using Common.UserService;
using Common.UserService.Interfaces;
using Enums;
using Infrastructure.Data;
using Infrastructure.Data.GlobalConstants.Issue;
using Infrastructure.Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

public class IssueService : IIssueService
{
    private readonly CheatSheetDbContext context;
    private readonly IMapper mapper;
    private readonly ICurrentUser userService;

    public IssueService(
        CheatSheetDbContext context,
        IMapper mapper, 
        ICurrentUser userService)
    {
        this.context = context;
        this.mapper = mapper;
        this.userService = userService;
    }

    public async Task<ICollection<IssueRespondModel>> GetIssues(IssueQuery? query)
    {
        IQueryable<Issue> issues = context.Issues.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.SearchString))
        {
            string wildcard = $"%{query.SearchString.ToLower()}%";

            issues = issues
                .Where(i => EF.Functions.Like(i.Title.ToLower(), wildcard));
        }


        issues = query.IssueSorting switch
        {
            IssueSorting.Deleted => issues.OrderBy(i => i.IsDeleted),
            IssueSorting.Newest => issues.OrderByDescending(i => i.CreatedOn),
            IssueSorting.Oldest => issues.OrderBy(i => i.CreatedOn),
        };

        var filteredIssues = issues.ProjectTo<IssueRespondModel>(mapper.ConfigurationProvider);


        return await Pagination<IssueRespondModel>.CreateAsync(filteredIssues, query.CurrentPage, 6);

    }

    public async Task<string> WithdrawIssue(string issueId)
    {
        var userId = userService.GetUserId();
        var findIssue = await context.Issues.FindAsync(issueId);

        if (findIssue == null)
        {
            throw new ServiceException(IssueMessages.NotFound);
        }

        if (findIssue.UserId != userId)
        {
            throw new ServiceException(IssueMessages.UnAuthorized);
        }

        try
        {
            context.Remove(findIssue);
            await context.SaveChangesAsync();
            return IssueMessages.SuccessfullyDeletedIssue;
        }
        catch (Exception e)
        {
            return IssueMessages.UnSuccessfullyDeletedIssue;
        }
    }

    public Task<string> CreateIssue()
    {
        throw new NotImplementedException();
    }
}