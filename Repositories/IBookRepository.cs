using bookstore_management_api.Models;

namespace bookstore_management_api.Repositories
{
    public interface IBookRepository
    {
        Task CreateBook(BookModels book);
        Task UpdateBook(BookModels book, BookModels bookAlreadyExists);
        Task<List<BookModels>> GetAllBooks();
        BookModels BookAlreadyExists(long bookId);
        Task<BookModels> GetBookById(long bookId);
        Task DeleteBook(BookModels book);
    }
}
