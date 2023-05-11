using _Project_CheatSheet.Features.Category.Models;

namespace _Project_CheatSheet.Features.Category.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryModel>> GetCategories();
    }
}