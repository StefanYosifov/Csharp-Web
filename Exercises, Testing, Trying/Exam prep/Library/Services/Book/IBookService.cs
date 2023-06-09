namespace Library.Services.Book
{
    using Models;
    using Models.BookViewModels;

    public interface IBookService
    {
        Task<ICollection<AllBookModels>> GetAllBooksAsync();
        Task AddBookToUserCollection(int id);
        Task DeleteBookAsync(int id);
        Task<ICollection<AllRequestBookModels>> GetMineBooksAsync();
        Task<ICollection<BookCategoryModel>> GetCategoriesAsync();
        Task AddBookAsync(AddPostBookModel bookModel);

    }
}
