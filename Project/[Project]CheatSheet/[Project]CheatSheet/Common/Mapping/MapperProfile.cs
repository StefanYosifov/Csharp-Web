namespace _Project_CheatSheet.Common.Mapping
{
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Identity.Models;
    using _Project_CheatSheet.Features.Likes.Models;
    using AutoMapper;

    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            this.CreateMap<LikeResourceModel, ResourceLike>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));

            this.CreateMap<RegisterModel, User>();
        }
    }
}
