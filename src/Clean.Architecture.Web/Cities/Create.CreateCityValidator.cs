using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Cities;

public class CreateCityValidator : Validator<CreateCityRequest>
{
  public CreateCityValidator()
  {
    RuleFor(x => x.CityName).NotEmpty().WithMessage("City name is required").MinimumLength(3).MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
