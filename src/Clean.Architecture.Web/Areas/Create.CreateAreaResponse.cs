using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Areas;

public class CreateAreaValidator : Validator<CreateAreaRequest>
{
  public CreateAreaValidator()
  {
    RuleFor(x => x.AreaName).NotEmpty().WithMessage("City name is required").MinimumLength(3).MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
