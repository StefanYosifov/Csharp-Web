using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.User;
using _Project_CheatSheet.Infrastructure.Data.Models.Base.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
            this.ResourceLikes = new HashSet<ResourceLike>();
            this.CommentLikes = new HashSet<CommentLike>();
            this.Comments = new HashSet<Comment>();
            this.UserCourses=new HashSet<UserCourses>();
        }

        [Url] public string? ProfilePictureUrl { get; set; }

        [MaxLength(UserConstants.DescriptionMaxLength)]
        public string? ProfileDescription { get; set; }

        [MaxLength(UserConstants.BackGroundImageMaxLength)]
        public string? ProfileBackground { get; set; }

        [MaxLength(UserConstants.EducationMaxLength)]
        public string? UserEducation { get; set; }

        [MaxLength(UserConstants.JobMaxLength)]
        public string? UserJob { get; set; }

        public ICollection<Resource> Resources { get; set; }
        public ICollection<ResourceLike> ResourceLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public ICollection<UserCourses> UserCourses { get; set; }
        public DateTime DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}