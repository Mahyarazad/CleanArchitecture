using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.UseCases.Areas;
public record AreaDTO(int id, string areaName, string? areaDisplayName, int? cityID, CityDTO? city)
{
}
