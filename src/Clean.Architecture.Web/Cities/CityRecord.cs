using Clean.Architecture.Web.Areas;

namespace Clean.Architecture.Web.Cities;

public record CityRecord(int id, string cityName, string? cityDisplayName, IEnumerable<AreaRecord>? areas)
{
}
