namespace Clean.Architecture.Web.Cities;

public class UpdateCityResponse(CityRecord city)
{
  public CityRecord City { get; set; } = city;
}
