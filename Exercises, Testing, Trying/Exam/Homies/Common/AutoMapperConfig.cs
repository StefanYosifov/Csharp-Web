namespace Homies.Common
{
    using AutoMapper;
    using Data.Models;
    using Models;
    using Models.EventModels;

    using static GlobalConstants.GlobalConstants.EventConstants;

    public class AutoMapperConfig:Profile
    {

        public AutoMapperConfig()
        {
            //Type
            CreateMap<Type, TypeViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            //Event

            CreateMap<Event, EventAllViewModel>()
                .ForMember(dest=>dest.Start,opt=>opt.MapFrom(src=>src.Start.ToString(DateTimeFormat)))
                .ForMember(dest=>dest.Type,opt=>opt.MapFrom(src=>src.Type.Name));

            CreateMap<Event, EventJoinedViewModel>()
                .ForMember(dest=>dest.Start,opt=>opt.MapFrom(src=>src.Start.ToString(DateTimeFormat)))
                .ForMember(dest=>dest.Type,opt=>opt.MapFrom(src=>src.Type.Name));

            CreateMap<EventAddViewModel, Event>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => DateTime.Parse(src.Start)))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => DateTime.Parse(src.End)));

            CreateMap<EventEditViewModel, Event>()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => DateTime.Parse(src.Start)))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => DateTime.Parse(src.End)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Event, EventDetailViewModel>()
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.ToString(DateTimeFormat)))
            .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start.ToString(DateTimeFormat)))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End.ToString(DateTimeFormat)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Organiser, opt => opt.MapFrom(src => src.Organiser.UserName))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name));
        }
    }
}
