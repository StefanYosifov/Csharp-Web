namespace _Project_CheatSheet.Controllers.Category.Services
{
    using _Project_CheatSheet.Controllers.Category.Interfaces;
    using _Project_CheatSheet.Controllers.Category.Models;
    using _Project_CheatSheet.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {

        private readonly CheatSheetDbContext context;
        public CategoryService(CheatSheetDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CategoryModel>> getCategories()
        {
            return await context.Categories
                .AsNoTracking().
                Select(x => new CategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArrayAsync();

        }
    }
}
