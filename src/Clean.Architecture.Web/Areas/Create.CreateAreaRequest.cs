using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Clean.Architecture.Web.Areas;

public class CreateAreaRequest
{
  public const string Route = "/Areas";

  [Required]
  public required string AreaName { get; set; }
  public string? AreaDisplayName { get; set; }
  public int? CityId{ get; set; }
}
