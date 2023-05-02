namespace CheatSheetProject.Helper
{
    using AutoMapper;
    using CheatSheetProject.Data.Models;
    using CheatSheetProject.Models;

    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            this.CreateMap<Resource, ResourceModel>();
        }
        
    }
}
