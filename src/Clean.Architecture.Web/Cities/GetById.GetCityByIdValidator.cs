using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Cities;

public class GetCityByIdValidator : Validator<GetCityByIdRequest>
{
  public GetCityByIdValidator()
  {
    RuleFor(x => x.CityId).GreaterThan(0);
  }
}
