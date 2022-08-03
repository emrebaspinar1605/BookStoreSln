using System;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BookOperations.CreateBook;
using WebAPI.BookOperations.DeleteBook;
using WebAPI.BookOperations.GetBooks;
using WebAPI.BookOperations.GetById;
using WebAPI.BookOperations.UpdateBook;
using WebAPI.DbOperations;

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
        {
            BookByIdVM result;
            try
            {
              GetBookByIdQuery query = new GetBookByIdQuery(_context);
              result = query.Handle(id);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok(result);
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
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
              DeleteBookQuery query = new DeleteBookQuery(_context);
              query.Handle(id);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
