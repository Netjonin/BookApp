using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bookapp.Data.Models;
using bookapp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookapp.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }

        //Create/Add a new book
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _service.AddBook(book);
            return Ok("Added");
        }

        //Read all books
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allBooks = _service.GetAllBooks();
            return Ok(allBooks);
        }

        //Update an existing book
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            _service.UpdateBook(id, book);
            return Ok(book);
        }

        //Delete a book
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }

        //Get a single book by id
        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
    }
}