using System;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IMapper _mapper;
    public BookController(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    [HttpGet]
        public IActionResult GetBooks()
        {
          GetBooksQuery query = new GetBooksQuery(_context,_mapper);
          var result = query.Handle();
          return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookByIdVM result;
            GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            try
            {
              query.BookId = id;
              validator.ValidateAndThrow(query);
              result = query.Handle();
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
            CreateBookQuery query = new CreateBookQuery(_context,_mapper);
            query.Model= newBook;
            CreateBookQueryValidator valid = new CreateBookQueryValidator();
            ValidationResult result = valid.Validate(query);
            if (!result.IsValid)
            {
              foreach (var item in result.Errors)
                Console.WriteLine($"Özellik {item.PropertyName}- ErrorMessage: {item.ErrorMessage}");
              return BadRequest();
            }
            else
            {
              query.Handle();
            }
           return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id , [FromBody] UpdateBookModels newBook)
        {
          UpdateBookQuery query = new UpdateBookQuery(_context);
          query.BookId = id;
          UpdateBookQueryValidator validator = new UpdateBookQueryValidator();
          try
          {
            validator.ValidateAndThrow(query);
            query.Model = newBook;
            query.Handle();
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
            DeleteBookQuery query = new DeleteBookQuery(_context);
            DeleteBookQueryValidator validator = new DeleteBookQueryValidator();
          try
          {
            query.BookId = id;
            validator.ValidateAndThrow(query);
            query.Handle();
          }
          catch (Exception ex)
          {
            return BadRequest(ex.Message);
          }
          return Ok();
        }
    }
}
