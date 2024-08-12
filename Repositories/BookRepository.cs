using bookstore_management_api.Data;
using bookstore_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_management_api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<BookModels> GetBookById(long bookId)
        {
            var bookReturned = await _context.Book.FindAsync(bookId);

            if (bookReturned == null)
            {
                throw new KeyNotFoundException($"Book with ID {bookId} was not found.");
            }

            return bookReturned;
        }
        public async Task<List<BookModels>> GetAllBooks()
        {
            try
            {
                return await _context.Book.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateBook(BookModels book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(BookModels book, BookModels bookAlreadyExists)
        {
            _context.Entry(bookAlreadyExists).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
        }

        public BookModels BookAlreadyExists(long bookId)
        {
            var bookExisting = _context.Book.Find(bookId);
            if (bookExisting == null)
            {
                throw new KeyNotFoundException($"Book with ID {bookId} was not found.");
            }
            else
            {
                return bookExisting;
            }
        }

        public async Task DeleteBook(BookModels book)
        {
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
