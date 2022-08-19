using System;
using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorQueryValidator : AbstractValidator<CreateAuthorQuery>
  {
    public CreateAuthorQueryValidator()
    {
      RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
      RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
      RuleFor(x => x.Model.SurName).NotEmpty().MinimumLength(2);
    }
  }
}