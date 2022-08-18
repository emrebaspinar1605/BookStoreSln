using FluentValidation;

namespace WebAPI.Application.GenreOperations.Commands.UpdateGenre
{
  public class UpdateGenreQueryValidator : AbstractValidator<UpdateGenreQuery>
  {
    public UpdateGenreQueryValidator()
    {
      RuleFor(g => g.Model.Name).MinimumLength(3).When(g => g.Model.Name != string.Empty);
      RuleFor(g => g.GenreId).GreaterThan(0);
    }
  }
}