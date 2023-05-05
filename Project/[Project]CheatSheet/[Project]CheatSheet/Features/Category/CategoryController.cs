namespace _Project_CheatSheet.Controllers.Category
{
    using _Project_CheatSheet.Controllers.Category.Interfaces;
    using _Project_CheatSheet.Controllers.Category.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


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
            var resources = await service.getCategories();
            return resources;
        }
    }
}
