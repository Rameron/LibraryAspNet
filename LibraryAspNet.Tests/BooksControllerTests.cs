using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Contracts;
using LibraryAspNet.BusinessLogic.Models;
using LibraryAspNet.DataAccess.Models;
using LibraryAspNet.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace LibraryAspNet.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        private BooksController _booksController;

        [SetUp]
        public void Setup()
        {
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(service=>service.GetBooksAsync()).Returns(GetTestBooks());
            _booksController = new BooksController(null, bookServiceMock.Object);
        }

        [Test]
        public async Task GetBooksAsyncAllTitlesNotNullOrEmpty()
        {
            var actResults = await _booksController.Get() as JsonResult;
            var booksList = (List<Book>)actResults.Value;

            Assert.That(booksList.Select(x => x.Title), Is.All.Not.Null);
            Assert.That(booksList.Select(x => x.Title), Is.All.Not.Empty);
        }

        [Test]
        public async Task GetBooksAsyncReturnJSonResult()
        {
            var actResults = await _booksController.Get();

            Assert.That(actResults, Is.TypeOf(typeof(JsonResult)));
        }


        private async Task<IEnumerable<Book>> GetTestBooks()
        {
            return await Task.Run(() =>
            {
                var books = new List<Book>
                {
                    new Book {Title = "Book A", Author = "Author A", Year = 1992},
                    new Book {Title = "Book B", Author = "Author B", Year = 1993},
                    new Book {Title = "Book C", Author = "Author C", Year = 1994},
                    new Book {Title = "Book D", Author = "Author D", Year = 1995},
                    new Book {Title = "Book E", Author = "Author E", Year = 1996}
                };
                return books;
            });
        }
    }
}