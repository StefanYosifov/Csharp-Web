namespace _Project_CheatSheet.Features.Profile.Models
{
    using _Project_CheatSheet.Common.ModelConstants;
    using System.ComponentModel.DataAnnotations;

    public class UserEditModel
    {
        public string? ProfilePictureUrl { get; set; }
        [StringLength(ModelConstants.UserDescriptionMaxLength,MinimumLength =ModelConstants.UserDescriptionMinLength)]
        public string? UserProfileDescription { get; set; }
        [StringLength(ModelConstants.UserBackGroundImageMaxLength,MinimumLength =ModelConstants.UserBackGroundImageMinLength)]
        public string? UserProfileBackground { get; set; }
        [StringLength(ModelConstants.UserEducationMaxLength,MinimumLength =ModelConstants.UserEducationMinLength)]
        public string? UserEducation { get; set; }
        [MaxLength(ModelConstants.UserJobMaxLength)]
        public string? UserJob { get; set; }
    }
}
