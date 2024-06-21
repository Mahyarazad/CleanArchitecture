using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Cities;

public class UpdateCityRequest
{
  public const string Route = "/Cities/{CityId:int}";
  public static string BuildRoute(int cityId) => Route.Replace("{CityId:int}", cityId.ToString());

  public int CityId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public required string CityName { get; set; }
  public string? DisplayCityName { get; set; }
}
