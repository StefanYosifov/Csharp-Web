namespace _Project_CheatSheet.Infrastructure.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base;
using GlobalConstants.Issue;

public class Issue : DeletableEntity
{
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(IssueConstants.IssueTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(IssueConstants.IssueDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Course))]
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;

    [Required] [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(CategoryIssue))]
    public int? CategoryIssueId { get; set; }
    public CategoryIssue? CategoryIssue { get; set; }
}