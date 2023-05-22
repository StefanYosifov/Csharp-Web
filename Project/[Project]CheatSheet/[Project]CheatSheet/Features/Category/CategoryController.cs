namespace _Project_CheatSheet.Features.Category
{
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("/category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }


        [Authorize]
        [HttpGet("get")]
        public async Task<IEnumerable<CategoryModel>> GetCategory()
        {
            var resources = await service.GetCategories();
            return resources;
        }
    }
}