﻿namespace _Project_CheatSheet.Features.Profile.Models
{
    using _Project_CheatSheet.Common.ModelConstants;
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }
        [MaxLength(ModelConstants.UserDescriptionMaxLength)]
        public string? UserProfileDescription { get; set; }
        [MaxLength(ModelConstants.UserBackGroundImageMaxLength)]
        public string? UserProfileBackground { get; set; }
        [MaxLength(ModelConstants.UserEducationMaxLength)]
        public string? UserEducation { get; set; }
        [MaxLength(ModelConstants.UserJobMaxLength)]
        public string? UserJob { get; set; }
    }
}
