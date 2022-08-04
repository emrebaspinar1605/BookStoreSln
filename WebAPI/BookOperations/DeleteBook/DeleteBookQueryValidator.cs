using FluentValidation;

namespace WebAPI.BookOperations.DeleteBook
{
  public class DeleteBookQueryValidator :AbstractValidator<DeleteBookQuery>
  {
    public DeleteBookQueryValidator()
    {
      RuleFor(c=> c.BookId).NotEmpty().GreaterThan(0);
    }
  }
}