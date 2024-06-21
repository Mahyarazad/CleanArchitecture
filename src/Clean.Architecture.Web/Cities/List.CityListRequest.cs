using Clean.Architecture.Web.Cities;

namespace Clean.Architecture.Web.Cities;

public class CityListRequest
{
  public const string Route = "/Cities/{Skip:int}&{Take:int}";

  public static string BuildRoute(int skip, int take) => Route.Replace("{Skip:int}", skip.ToString()).Replace("{Take:int}", take.ToString());
  public int Skip { get; set; }
  public int Take { get; set; }

}
