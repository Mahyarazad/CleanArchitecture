using System.ComponentModel.DataAnnotations;
using Clean.Architecture.Web.Areas;

namespace Clean.Architecture.Web.Cities;

public class CreateCityRequest
{
  public const string Route = "/Cities";
  [Required]
  public required string CityName { get; set; }
  public string? CityDisplayName { get; set; }
  public IEnumerable<CreateAreaRequest>? Areas { get; set; }
}

  
