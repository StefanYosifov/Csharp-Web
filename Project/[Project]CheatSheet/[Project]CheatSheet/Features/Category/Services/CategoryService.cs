using _Project_CheatSheet.Data;
using _Project_CheatSheet.Features.Category.Interfaces;
using _Project_CheatSheet.Features.Category.Models;
using _Project_CheatSheet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Features.Category.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CheatSheetDbContext context;

        public CategoryService(CheatSheetDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking().Select(x => new CategoryModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArrayAsync();
        }
    }
}