using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Cities;

public class DeleteCityValidator :Validator<DeleteCityRequest>
{
  public DeleteCityValidator()
  {
    RuleFor(x=>x.CityId).GreaterThan(0);
  }
}
