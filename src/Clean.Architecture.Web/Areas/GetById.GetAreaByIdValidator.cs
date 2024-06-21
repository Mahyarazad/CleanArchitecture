using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Areas;

public class GetAreaByIdValidator : Validator<GetAreaByIdRequest>
{
  public GetAreaByIdValidator()
  {
    RuleFor(x => x.AreaId).GreaterThan(0);
  }
}
