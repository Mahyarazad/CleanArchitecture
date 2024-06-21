namespace Clean.Architecture.Web.Areas;

public class DeleteAreaRequest
{
  public const string Route = "/Areas/{AreaId:int}";

  public static string BuildRoute(int areaId) => Route.Replace("{AreaId:int}", areaId.ToString());
  public int AreaId { get; set; }
}
