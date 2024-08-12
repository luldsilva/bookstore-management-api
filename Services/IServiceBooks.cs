using bookstore_management_api.Models;

namespace bookstore_management_api.Services
{
    public interface IServiceBooks
    {
        Task<List<BookModels>> GetAllBooks();
        Task BookRegister(BookModels book);
        Task<UpdateBookResult> UpdateBook(BookModels book);
        void DeleteBook(BookModels book);
        Task<BookModels> GetBookById(long bookId);
    }
}
