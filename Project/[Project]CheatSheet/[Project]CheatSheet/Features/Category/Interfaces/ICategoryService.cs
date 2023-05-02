namespace _Project_CheatSheet.Controllers.Category.Interfaces
{
    using _Project_CheatSheet.Controllers.Category.Models;

    public interface ICategoryService
    {

        public Task<IEnumerable<CategoryModel>> getCategories();

    }
}
