
using Clean.Architecture.UseCases.Cities;

namespace Clean.Architecture.Web.Cities;

public class CityListResponse
{
  public List<CityDTO> Cities { get; set; } = [];
}
