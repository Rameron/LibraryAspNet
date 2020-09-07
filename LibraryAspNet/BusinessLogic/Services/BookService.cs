using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Contracts;
using LibraryAspNet.BusinessLogic.Models;
using LibraryAspNet.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryAspNet.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        public readonly LibraryContext _libraryContext;

        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _libraryContext.Books.Select(x => x.ToBusinessLogicModel()).ToListAsync();
        }

        public async Task<Book> AddBookAsync(Book newBook)
        {
            _libraryContext.Books.Add(newBook.ToDatabaseModel());
            await _libraryContext.SaveChangesAsync();

            return newBook;
        }

        public async Task<Book> GetBookAsync(int bookId)
        {
            var gettingBook = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (gettingBook == null)
            {
                throw new Exception("Book not found");
            }

            return gettingBook.ToBusinessLogicModel();
        }

        public async Task<Book> UpdateBookAsync(int bookId, Book updateBook)
        {
            var updatingBook = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (updatingBook == null)
            {
                throw new Exception("Book not found");
            }
            _libraryContext.Books.Update(updateBook.ToDatabaseModel());
            await _libraryContext.SaveChangesAsync();

            return updateBook;
        }

        public async Task<Book> DeleteBookAsync(int bookId)
        {
            var removingBook = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (removingBook == null)
            {
                throw new Exception("User not found");
            }
            _libraryContext.Books.Remove(removingBook);
            await _libraryContext.SaveChangesAsync();

            return removingBook.ToBusinessLogicModel();
        }
    }
}
