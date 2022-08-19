using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorQueryValidator : AbstractValidator<UpdateAuthorQuery>
  {
    public UpdateAuthorQueryValidator()
    {
      RuleFor(x => x.AuthorId).NotEmpty().GreaterThan(0);
      RuleFor(x => x.Model.Name ).MinimumLength(3);
      RuleFor(x => x.Model.SurName).MinimumLength(2);
    }
  }
}