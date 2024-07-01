using System.Runtime.CompilerServices;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities;
public record struct CityDTO(int id, string cityName, string? cityDisplayName, IEnumerable<AreaDTO>? areaDto) 
{
  
}
