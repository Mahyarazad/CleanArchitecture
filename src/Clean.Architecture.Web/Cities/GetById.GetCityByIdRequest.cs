namespace Clean.Architecture.Web.Cities;

public class GetCityByIdRequest
{
  public const string Route = "/Cities/{CityId:int}";

  public static string BuildRoute(int cityId) => Route.Replace("{CityId:int}", cityId.ToString());
  public int CityId { get; set; }

}
