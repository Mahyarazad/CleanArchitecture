using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Cities;
using Clean.Architecture.UseCases.Cities.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;
public class ListCitiesQueryService : IListCitiesQueryService
{
  private readonly AppDbContext _dbContext;
  public ListCitiesQueryService(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<IEnumerable<CityDTO>> ListAsync(int skip, int take, CancellationToken ctx)
  {
    // todo: add filtering and pagination
    var result = await _dbContext.Cities.Include(x=>x.Aera)
      .OrderBy(x => x.Id)
      .Skip(skip)
      .Take(take)
      .Select(x=> new CityDTO(x.Id, x.CityName, x.CityDisplayName, x.Aera.Select(a=> new AreaDTO(a.Id, a.AreaName, a.AreaDisplayName, a.CityId, null))))
      .ToListAsync(ctx);
    return result;
  }

}
