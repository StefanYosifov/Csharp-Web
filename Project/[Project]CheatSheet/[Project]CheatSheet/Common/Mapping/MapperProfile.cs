namespace _Project_CheatSheet.Common.Mapping
{
    using AutoMapper;
    using Features.Comment.Models;
    using Features.Course.Models;
    using Features.Identity.Models;
    using Features.Issue.Models;
    using Features.Likes.Models;
    using Features.Profile.Models;
    using Features.Resources.Models;
    using Features.Topics.Models;
    using GlobalConstants;
    using Infrastructure.Data.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Likes
            CreateMap<LikeResourceModel, ResourceLike>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));

            CreateMap<LikeResourceModelAdd, ResourceLike>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));


            //Authentication
            CreateMap<RegisterModel, User>();

            //Profile
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.UserProfileDescription, opt => opt.MapFrom(src => src.ProfileDescription))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePictureUrl))
                .ForMember(dest => dest.UserJob, opt => opt.MapFrom(src => src.UserJob))
                .ForMember(dest => dest.UserEducation, opt => opt.MapFrom(src => src.UserEducation))
                .ForMember(dest => dest.UserProfileBackground, opt => opt.MapFrom(src => src.ProfileBackground));


            //Resources

            //We have overriding
            CreateMap<Resource, ResourceModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<Resource, ResourceModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.UserProfileImageUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)))
                .ForMember(dest => dest.TotalLikes,
                    opt => opt.MapFrom(src => src.ResourceLikes.Count(rl => rl.ResourceId == src.Id)));

            CreateMap<Resource, DetailResources>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.ResourceLikes.Count))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)));

            //Comments

            CreateMap<Comment, CommentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.ResourceId.ToString()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes));


            //Courses
            CreateMap<Course, CourseRespondModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics.Select(t => new TopicsRespondModel
                {
                    TopicId = t.Id.ToString(),
                    Name = t.Name
                })));

            CreateMap<Course, CourseRespondPaymentModel>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartTime,
                    opt => opt.MapFrom(src => src.StartDate.ToString(Formatter.DateOnlyFormatter)));


            CreateMap<Course, CourseRespondAllModel>()
                .BeforeMap((src, dest) => dest.HasPaid = false)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                .ForMember(dest => dest.TopicsCount, opt => opt.MapFrom(src => src.Topics.Count))
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate.ToString(Formatter.DateOnlyFormatter)))
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src => src.EndDate.ToString(Formatter.DateOnlyFormatter)));


            //Topics

            CreateMap<Topic, TopicRespondModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.VideoId, opt => opt.MapFrom(src => src.VideoId.ToString()))
                .ForMember(dest => dest.VideoName, opt => opt.MapFrom(src => src.Video.Name));


            CreateMap<Topic, TopicsRespondModel>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StarTime,
                    opt => opt.MapFrom(src => src.StartTime.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.EndTime,
                    opt => opt.MapFrom(src => src.EndTime.ToString(Formatter.DateFormatter)));


            CreateMap<Issue, IssueRespondModel>()
                .ForMember(dest=>dest.LocationIssue,opt=>opt.MapFrom(src=>src.CategoryIssue!.LocationIssue));

            CreateMap<IssueRespondModel, Issue>();
        }
    }
}