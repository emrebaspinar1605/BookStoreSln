using System;
using FluentValidation;
using WebAPI.Common;

namespace WebAPI.BookOperations.CreateBook
{
  public class CreateBookQueryValidator :AbstractValidator<CreateBookQuery>
  {
    public CreateBookQueryValidator()
    {
      RuleFor(c=> c.Model.GenreID).GreaterThan(0).LessThan(5);
      RuleFor(c=> c.Model.Name).NotEmpty().MinimumLength(3);
      RuleFor(c=> c.Model.PageCount).GreaterThan(0);
      RuleFor(c=> c.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
    }
  }
}