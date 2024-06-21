using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Cities;

public class UpdateCitiesValidator : Validator<UpdateCityRequest>
{
  public UpdateCitiesValidator()
  {
    RuleFor(x => x.CityName)
      .NotEmpty()
      .WithMessage("City name is required.")
      .MinimumLength(3)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.CityId)
      .Must((args, cityId) => args.Id == cityId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
