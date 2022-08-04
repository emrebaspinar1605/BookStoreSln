using FluentValidation;

namespace WebAPI.BookOperations.UpdateBook
{
  public class UpdateBookQueryValidator :AbstractValidator<UpdateBookQuery>
  {
    public UpdateBookQueryValidator()
    {
      RuleFor(c=> c.BookId).NotEmpty().GreaterThan(0);
    }
  }
}