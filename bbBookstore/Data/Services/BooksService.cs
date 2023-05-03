using bbBookstore.Data.Base;
using bbBookstore.Data.ViewModels;
using bbBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bbBookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly ApplicationDbContext _context;

        public BooksService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                BookTitle = data.BookTitle,
                Description = data.Description,
                Price = data.Price,
                BookImage = data.BookImage,
                BookGenre = data.BookGenre,
                NumOfPages = data.NumOfPages,
                ISBN = data.ISBN,
                Review = data.Review,
                PublisherId = data.PublisherId,
                AuthorId = data.AuthorId
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBooksByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(p => p.Publisher)
                .Include(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);
            return bookDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.FirstName).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbBook != null)
            {
                dbBook.BookTitle = data.BookTitle;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.BookImage = data.BookImage;
                dbBook.BookGenre = data.BookGenre;
                dbBook.NumOfPages = data.NumOfPages;
                dbBook.ISBN = data.ISBN;
                dbBook.Review = data.Review;
                dbBook.PublisherId = data.PublisherId;
                dbBook.AuthorId = data.AuthorId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
