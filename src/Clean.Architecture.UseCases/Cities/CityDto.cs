using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.UseCases.Areas;
public record CityDTO(int id, string cityName, string? cityDisplayName, IEnumerable<AreaDTO>? areaDto)
{
}
