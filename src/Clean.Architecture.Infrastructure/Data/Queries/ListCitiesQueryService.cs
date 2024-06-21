using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Cities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
      .Select(x=> new CityDTO(x.Id, x.CityName, x.CityDisplayName, x.Aera.Select(a=> new AreaDTO(a.Id, a.AreaName, a.AreaDisplayName, null, null))))
      .ToListAsync(ctx);
    return result;
  }

}
