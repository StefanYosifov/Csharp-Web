namespace Library.Common.Mapping
{
    using AutoMapper;
    using Data.Models;
    using Models;
    using Models.BookViewModels;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, AllBookModels>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Book, AllRequestBookModels>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, BookCategoryModel>();

            CreateMap<AddPostBookModel, Book>()
                .ForMember(dest=>dest.ImageUrl,opt=>opt.MapFrom(src=>src.Url));
        }
    }
}