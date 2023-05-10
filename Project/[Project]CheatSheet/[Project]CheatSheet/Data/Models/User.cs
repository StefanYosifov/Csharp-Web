using _Project_CheatSheet.Common.ModelConstants;
using _Project_CheatSheet.Data.Models.Base.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _Project_CheatSheet.Data.Models
{
    public class User : IdentityUser,IEntity
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
            this.ResourceLikes = new HashSet<ResourceLike>();
            this.CommentLikes = new HashSet<CommentLike>();
            this.Comments = new HashSet<Comment>();
        }

        public string? ProfilePictureUrl { get; set; }
        [MaxLength(ModelConstants.UserDescriptionMaxLength)]
        public string? ProfileDescription { get; set; }
        [MaxLength(ModelConstants.UserBackGroundImageMaxLength)]
        public string? ProfileBackground { get; set; }
        [MaxLength(ModelConstants.UserEducationMaxLength)]
        public string? UserEducation { get;set; }
        [MaxLength(ModelConstants.UserJobMaxLength)]
        public string? UserJob { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<ResourceLike> ResourceLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public DateTime CreatedOn { get ; set ; }
        public string CreatedBy { get ; set ; }
        public DateTime UpdatedOn { get ; set ; }
        public string UpdatedBy { get ; set ; }
        public DateTime DeletedOn { get ; set ; }
        public string DeletedBy { get ; set ; }
        public bool IsDeleted { get ; set ; }
    }
}
