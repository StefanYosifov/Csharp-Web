namespace CheatSheetProject.Services
{
    using Microsoft.AspNetCore.Mvc;
    using CheatSheetProject.Data.Data;
    using CheatSheetProject.Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using CheatSheetProject.Models;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class Resource :IResource
    {
        private readonly CheatSheetProjectDbContext context;
        private readonly IMapper mapper;
        public Resource(CheatSheetProjectDbContext context,
                        IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpPost]
        public Task<ResourceModel> addResource(string title, string content, string ImageUrl)
        {
            var resourceModel=new ResourceModel()
            {
                Title = title,
                Content = content,
                ImageUrl=ImageUrl,
                UserId=Identity
            }
        }

        [HttpGet]
        public async Task<IEnumerable<ResourceModel>> GetAllPublicResources()
        {
         IEnumerable<ResourceModel> resources
                =await context.Resources.ProjectTo<ResourceModel>(mapper.ConfigurationProvider).ToListAsync();
            return resources;
        }

        public async Task<IEnumerable<ResourceModel>> getMyResources(int userId)
        {
            IEnumerable<ResourceModel> resources
                = await context.Resources.ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Where(u => u.UserId == userId).ToListAsync();

            return resources;
        }

       
    }
}
