using FluentValidation;
using WebAPI.Application.BookOperations.Commands.DeleteBook;

namespace WebAPI.Application.BookOperations.Queries.DeleteBook
{
  public class DeleteBookQueryValidator :AbstractValidator<DeleteBookQuery>
  {
    public DeleteBookQueryValidator()
    {
      RuleFor(c=> c.BookId).NotEmpty().GreaterThan(0);
    }
  }
}