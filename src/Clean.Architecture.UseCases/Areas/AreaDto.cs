using Clean.Architecture.UseCases.Cities;

namespace Clean.Architecture.UseCases.Areas;
public record AreaDTO(int id, string areaName, string? areaDisplayName, int? cityID, CityDTO? city)
{
}
