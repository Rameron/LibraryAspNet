using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Models;

namespace LibraryAspNet.BusinessLogic.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> AddBookAsync(Book newBook);
        Task<Book> GetBookAsync(int bookId);
        Task<Book> UpdateBookAsync(int bookId, Book updateBook);
        Task<Book> DeleteBookAsync(int bookId);
    }
}
