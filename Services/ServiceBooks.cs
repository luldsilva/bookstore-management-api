using bookstore_management_api.Models;
using bookstore_management_api.Repositories;

namespace bookstore_management_api.Services
{
    public class ServiceBooks : IServiceBooks
    {
        private readonly IBookRepository _bookRepository;

        public ServiceBooks(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<BookModels> GetBookById(long bookId)
        {
            return _bookRepository.GetBookById(bookId);
        }
        public Task<List<BookModels>> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public async Task BookRegister(BookModels book)
        {
            await _bookRepository.CreateBook(book);
        }

        public async Task<UpdateBookResult> UpdateBook(BookModels book)
        {
            try
            {
                var bookAlreadyExists = BookAlreadyExists(book.Id);
                await _bookRepository.UpdateBook(book, bookAlreadyExists);
                return new UpdateBookResult { Success = true, Message = "Book updated successfully." };
            }
            catch (KeyNotFoundException ex)
            {

                return new UpdateBookResult { Success = false, Message = ex.Message };
            }
        }

        public BookModels BookAlreadyExists(long bookId)
        {
             return _bookRepository.BookAlreadyExists(bookId);
        }

        public void DeleteBook(BookModels book)
        {
             _bookRepository.DeleteBook(book);
        }

    }
}
