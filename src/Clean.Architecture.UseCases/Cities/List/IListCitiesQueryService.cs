using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.List;
public interface IListCitiesQueryService
{
  Task<IEnumerable<CityDTO>> ListAsync(int skip, int take, CancellationToken ctx);
}
