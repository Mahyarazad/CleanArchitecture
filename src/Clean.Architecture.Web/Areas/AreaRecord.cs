using Clean.Architecture.Web.Cities;

namespace Clean.Architecture.Web.Areas;

public record AreaRecord(int id, string areaName, string? areaDisplayName, int? cityId, CityRecord? city)
{
}
