using Clean.Architecture.Web.Areas;

namespace Clean.Architecture.Web.Areas;

public class AreaListRequest
{
  public const string Route = "/Areas/{Skip:int}&{Take:int}";

  public static string BuildRoute(int skip, int take) => Route.Replace("{Skip:int}", skip.ToString()).Replace("{Take:int}", take.ToString());
  public int Skip { get; set; }
  public int Take { get; set; }

}
