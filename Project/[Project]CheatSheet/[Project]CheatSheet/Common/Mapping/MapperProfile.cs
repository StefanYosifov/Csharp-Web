﻿namespace _Project_CheatSheet.Common.Mapping
{
    using _Project_CheatSheet.Controllers.Resources.Models;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Identity.Models;
    using _Project_CheatSheet.Features.Likes.Models;
    using _Project_CheatSheet.Common.ModelConstants;
    using AutoMapper;
    using _Project_CheatSheet.Features.Resources.Models;
    using _Project_CheatSheet.Features.Profile.Models;

    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            //Likes
            this.CreateMap<LikeResourceModel, ResourceLike>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));

            this.CreateMap< LikeResourceModelAdd,ResourceLike >()
                .ForMember(dest=>dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));


            //Authentication
            this.CreateMap<RegisterModel, User>();

            //Profile
            this.CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.UserDescription, opt => opt.MapFrom(src => src.ProfileDescription))
                .ForMember(dest => dest.UserProfilePicture, opt => opt.MapFrom(src => src.ProfilePictureUrl));



            //Resources

            //We have overriding
            CreateMap<Resource, ResourceModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<Resource, ResourceModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.User.UserName.ToString()))
                .ForMember(dest=>dest.UserProfileImage,opt=>opt.MapFrom(src=>src.User.ProfilePictureUrl))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.CreatedAt.ToString(ModelConstants.dateFormatter)))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)));

            CreateMap<Resource, DetailResources>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.CreatedAt.ToString(ModelConstants.dateFormatter)))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.ResourceLikes.Count))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)));

          



        }
    }
}
