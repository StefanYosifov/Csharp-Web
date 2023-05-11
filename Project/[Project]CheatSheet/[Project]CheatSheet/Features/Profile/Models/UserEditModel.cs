﻿namespace _Project_CheatSheet.Features.Profile.Models
{
    using _Project_CheatSheet.GlobalConstants.User;
    using System.ComponentModel.DataAnnotations;

    public class UserEditModel
    {
        public string? ProfilePictureUrl { get; set; }
        [StringLength(UserConstants.DescriptionMaxLength, MinimumLength = UserConstants.DescriptionMinLength)]
        public string? ProfileDescription { get; set; }
        [StringLength(UserConstants.BackGroundImageMaxLength, MinimumLength = UserConstants.BackGroundImageMinLength)]
        public string? ProfileBackground { get; set; }
        [StringLength(UserConstants.EducationMaxLength, MinimumLength = UserConstants.EducationMinLength)]
        public string? UserEducation { get; set; }
        [MaxLength(UserConstants.JobMaxLength)]
        public string? UserJob { get; set; }
    }
}
