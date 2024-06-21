using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Areas.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;
public class ListAreasQueryService : IListAreasQueryService
{
  private readonly AppDbContext _dbContext;
  public ListAreasQueryService(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<IEnumerable<AreaDTO>> ListAsync(int skip, int take, CancellationToken ctx)
  {
    // todo: add filtering and pagination
    var result = await _dbContext.Areas.Include(x=>x.City)
      .OrderBy(x => x.Id)
      .Skip(skip)
      .Take(take)
      .Select(x=> new AreaDTO(x.Id, x.AreaName, x.AreaDisplayName,x.CityId, x.City != null ? new CityDTO(x.City.Id!, x.City.CityName, x.City.CityDisplayName, null) : null))
      .ToListAsync(ctx);
    return result;
  }

}
