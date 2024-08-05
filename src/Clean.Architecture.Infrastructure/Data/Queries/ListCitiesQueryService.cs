using System.Collections;
using System.Linq;
using AutoMapper;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Cities;
using Clean.Architecture.UseCases.Cities.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;
public class ListCitiesQueryService : IListCitiesQueryService
{
  private readonly AppDbContext _dbContext;
  private readonly IMapper _mapper;
  public ListCitiesQueryService(AppDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper; 
  }
  public async Task<IEnumerable<CityDTO>> ListAsync(int skip, int take, CancellationToken ctx)
  {
    // todo: add filtering and pagination
    var result = await _dbContext.Cities.Include(x => x.Aera)
                                        .OrderBy(x => x.Id)
                                        .Skip(skip)
                                        .Take(take)
                                        .Select( x=> _mapper.Map<CityDTO>(x))
                                        .ToListAsync();

    return result;
  }

}
