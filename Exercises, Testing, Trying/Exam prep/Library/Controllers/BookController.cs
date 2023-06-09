namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.BookViewModels;
    using Services.Book;

    public class BookController : BaseController
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var bookResult = await _service.GetAllBooksAsync();
            return View(bookResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            try
            {
                await _service.AddBookToUserCollection(id);
                return RedirectToAction("Mine");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            try
            {
                await _service.DeleteBookAsync(id);
                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var bookResult = await _service.GetMineBooksAsync();

            return View(bookResult);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _service.GetCategoriesAsync();
            var addBooks = new AddGetBookModel()
            {
                Categories = categories
            };

            return View(addBooks);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(AddPostBookModel bookModel)
        {

            try
            {
                await _service.AddBookAsync(bookModel);
                return RedirectToAction("Mine");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
