using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.Web.Cities;

public class CityListResponse
{
  public List<CityDTO> Cities { get; set; } = [];
}
