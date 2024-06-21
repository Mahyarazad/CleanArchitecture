using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Areas;

public class DeleteAreaValidator :Validator<DeleteAreaRequest>
{
  public DeleteAreaValidator()
  {
    RuleFor(x=>x.AreaId).GreaterThan(0);
  }
}
