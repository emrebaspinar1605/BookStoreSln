using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BookOperations.CreateBook;
using WebAPI.BookOperations.GetBooks;
using WebAPI.BookOperations.UpdateBook;
using WebAPI.DbOperations;
using WebAPI.Models;
using static WebAPI.BookOperations.CreateBook.CreateBookQuery;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
           GetBooksQuery query = new GetBooksQuery(_context);
          var result = query.Handle();
          return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {try
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context);
            var result = query.Handle(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
        }
        [HttpPost]
        public IActionResult AddBook([FromBody]CreateBookModel newBook)
        {
            CreateBookQuery query = new CreateBookQuery(_context);
            try
            {
              query.Model= newBook;
              query.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id , [FromBody] UpdateBookModels newBook)
        {
           UpdateBookQuery query = new UpdateBookQuery(_context);
           try
           {
            query.Model = newBook;
            query.Handle(id);
                return Ok();
           }
           catch (Exception e)
           {
                return BadRequest(e.Message);
           }
        }
        [HttpPost("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id == id);
            if (book is null)
            { return BadRequest(); }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
