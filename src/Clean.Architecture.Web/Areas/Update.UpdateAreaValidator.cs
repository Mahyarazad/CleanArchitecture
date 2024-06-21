using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Areas;

public class UpdateAreaValidator : Validator<UpdateAreaRequest>
{
  public UpdateAreaValidator()
  {
    RuleFor(x => x.AreaName)
      .NotEmpty()
      .WithMessage("Area name is required.")
      .MinimumLength(3)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.AreaId)
      .Must((args, areaId) => args.Id == areaId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
