using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.AuthorOperations.Commands.CreateAuthor;
using WebAPI.Application.AuthorOperations.Commands.DeleteAuthor;
using WebAPI.Application.AuthorOperations.Commands.UpdateAuthor;
using WebAPI.Application.AuthorOperations.Queries.GetAuthorById;
using WebAPI.Application.AuthorOperations.Queries.GetAuthors;
using WebAPI.DbOperations;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]s")]
  public class AuthorController : Controller
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public AuthorController(IMapper mapper, BookStoreDbContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    [HttpGet]
    public IActionResult GetAuthors()
    {
      GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
      var result = query.Handle();
      return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      
      GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(_context,_mapper);
      GetAuthorDetailsQueryValidator validator = new GetAuthorDetailsQueryValidator();

      query.AuthorId = id;
      validator.ValidateAndThrow(query);

      var result = query.Handle();
      return Ok(result);
    }
    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
    {
      CreateAuthorQuery query = new CreateAuthorQuery(_context);
      query.Model = newAuthor;

      CreateAuthorQueryValidator validator = new CreateAuthorQueryValidator();
      validator.ValidateAndThrow(query);

      query.Handle();
      return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id , [FromBody] UpdateAuthorModel newAuthor)
    {
      UpdateAuthorQuery query = new UpdateAuthorQuery(_context,_mapper);
      query.AuthorId = id;
      query.Model = newAuthor;

      UpdateAuthorQueryValidator validator = new UpdateAuthorQueryValidator();
      validator.ValidateAndThrow(query);

      query.Handle();
      return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
      DeleteAuthorQuery query = new DeleteAuthorQuery(_context);
      query.AuthorId = id;

      DeleteAuthorQueryValidator validator = new DeleteAuthorQueryValidator();
      validator.ValidateAndThrow(query);
      
      query.Handle();
      return Ok();

    }
  }
}