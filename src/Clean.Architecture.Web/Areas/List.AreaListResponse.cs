using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.Web.Areas;

public class AreaListResponse
{
  public List<AreaDTO> Areas { get; set; } = [];
}
