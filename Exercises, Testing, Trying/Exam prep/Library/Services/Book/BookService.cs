namespace Library.Services.Book
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.BookViewModels;
    using Users;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public BookService(
            LibraryDbContext context,
            IUserService userService,
            IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }


        public async Task<ICollection<AllBookModels>> GetAllBooksAsync()
        {
            var userId = _userService.GetUserId();
            return await _context.Books.Where(b => b.UsersBooks.All(uc => uc.CollectorId !=userId))
                .ProjectTo<AllBookModels>(_mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task AddBookToUserCollection(int id)
        {
            var userId = _userService.GetUserId();

            if (await _context.UserBooks.AnyAsync(ub => ub.BookId == id && ub.CollectorId == userId))
            {
                return;
            }

            var userBook = new IdentityUserBook()
            {
                BookId = id,
                CollectorId = userId
            };

            await _context.UserBooks.AddAsync(userBook);
            await _context.SaveChangesAsync();


        }

        public async Task DeleteBookAsync(int id)
        {
            var userId = _userService.GetUserId();
            var findBook = await _context.UserBooks.FirstOrDefaultAsync(ub => ub.BookId == id && ub.CollectorId == userId);

            _context.Remove(findBook);
            await _context.SaveChangesAsync();
        }


        public async Task<ICollection<AllRequestBookModels>> GetMineBooksAsync()
        {
            var userId = _userService.GetUserId();
            return await _context.Books.Where(b => b.UsersBooks.Any(ub => ub.CollectorId == userId))
                .ProjectTo<AllRequestBookModels>(_mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<ICollection<BookCategoryModel>> GetCategoriesAsync() => 
            await _context.Categories.ProjectTo<BookCategoryModel>(_mapper.ConfigurationProvider).ToArrayAsync();

        public async Task AddBookAsync(AddPostBookModel bookModel)
        {

            var book123 = await _context.Books.Select(b=>new AddPostBookModel()
            {
                Description = b.Description,
            }).FirstOrDefaultAsync();


            var book = _mapper.Map<Book>(bookModel);
            var userId = _userService.GetUserId();

            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }
    }
}