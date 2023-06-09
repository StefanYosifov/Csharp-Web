﻿namespace _Project_CheatSheet.Features.Course.Models
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Data.GlobalConstants.Course;

    public class CourseRespondModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.TitleMaxLength, MinimumLength = CourseConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.DescriptionMaxLength, MinimumLength = CourseConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(CourseConstants.PriceMinRange, CourseConstants.PriceMaxRange)]
        public decimal Price { get; set; }

        [Required] [Url] public string  ImageUrl { get; set; }

        public bool HasPaid { get; set; }

        [Required] public string Category { get; set; } = null!;

        public ICollection<TopicsRespondModel> Topics { get; set; } = null!;
    }
}