using Clean.Architecture.UseCases.Cities;

namespace Clean.Architecture.UseCases.Areas;
public record struct AreaDTO(int id, string areaName, string? areaDisplayName, int? cityID, CityDTO? city)
{
}
