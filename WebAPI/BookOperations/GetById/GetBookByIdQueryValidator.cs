using FluentValidation;

namespace WebAPI.BookOperations.GetById
{
  public class GetBookByIdQueryValidator :AbstractValidator<GetBookByIdQuery>
  {
    public GetBookByIdQueryValidator()
    {
      RuleFor(c=> c.BookId).NotEmpty().GreaterThan(0);
    }
  }
}