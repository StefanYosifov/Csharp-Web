﻿namespace _Project_CheatSheet.Features.Issue.Models
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Data.GlobalConstants.Issue;

    public class IssueRequestModel
    {

        public int Id { get; set; }

        [Required]
        public IssueCategoryModel IssueCategory { get; set; }

        [Required]
        [StringLength(IssueConstants.IssueTitleMaxLength,MinimumLength = IssueConstants.IssueTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(IssueConstants.IssueDescriptionMaxLength,MinimumLength = IssueConstants.IssueDescriptionMinLength)]
        public string Description { get; set; }

    }
}
