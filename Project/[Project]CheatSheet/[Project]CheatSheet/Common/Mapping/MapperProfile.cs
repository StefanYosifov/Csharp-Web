using _Project_CheatSheet.Features.Course.Models;
using _Project_CheatSheet.Features.Identity.Models;
using _Project_CheatSheet.Features.Likes.Models;
using _Project_CheatSheet.Features.Profile.Models;
using _Project_CheatSheet.Features.Resources.Models;
using _Project_CheatSheet.Features.Topics.Models;
using _Project_CheatSheet.GlobalConstants;
using _Project_CheatSheet.Infrastructure.Data.Models;
using AutoMapper;

namespace _Project_CheatSheet.Common.Mapping
{
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
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)));

            CreateMap<Resource, DetailResources>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.ResourceLikes.Count))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)));

            //Courses
            CreateMap<Course, CourseRespondModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics.Select(t => new TopicsRespondModel
                {
                    TopicId = t.Id.ToString(),
                    Name = t.Name
                })));


            CreateMap<Course, CourseRespondAllModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.TopicsCount, opt => opt.MapFrom(src => src.Topics.Count))
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate.ToString(Formatter.DateOnlyFormatter)))
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src => src.EndDate.ToString(Formatter.DateOnlyFormatter)));


            //Topics

            CreateMap<Topic, TopicRespondModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.VideoId, opt => opt.MapFrom(src => src.VideoId.ToString()))
                .ForMember(dest => dest.VideoName, opt => opt.MapFrom(src => src.Video.Name))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.Video.VideoUrl));


            CreateMap<Topic, TopicsRespondModel>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StarTime,
                    opt => opt.MapFrom(src => src.StartTime.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.EndTime,
                    opt => opt.MapFrom(src => src.EndTime.ToString(Formatter.DateFormatter)));
        }
    }
}