using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Areas;

public class UpdateAreaRequest
{
  public const string Route = "/Areas/{AreaId:int}";
  public static string BuildRoute(int areaID) => Route.Replace("{AreaId:int}", areaID.ToString());

  public int AreaId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public required string AreaName { get; set; }
  public string? DisplayAreaName { get; set; }
  public int? CityId { get; set; }
}
