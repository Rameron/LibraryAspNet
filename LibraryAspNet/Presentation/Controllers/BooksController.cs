using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Contracts;
using LibraryAspNet.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryAspNet.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new JsonResult(await _bookService.GetBooksAsync());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return new JsonResult(await _bookService.GetBookAsync(id));
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            return new JsonResult(await _bookService.AddBookAsync(book));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Book book)
        {
            return new JsonResult(await _bookService.UpdateBookAsync(id, book));
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return new JsonResult(await _bookService.DeleteBookAsync(id));
        }
    }
}
