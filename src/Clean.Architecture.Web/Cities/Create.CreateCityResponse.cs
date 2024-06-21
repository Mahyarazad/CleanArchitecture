using System.ComponentModel.DataAnnotations;
using Clean.Architecture.Web.Areas;

namespace Clean.Architecture.Web.Cities;

public class CreateCityResponse(int id, string cityName)
{
  public int Id { get; set; } = id;
  public string CityName { get; set; } = cityName;
}
