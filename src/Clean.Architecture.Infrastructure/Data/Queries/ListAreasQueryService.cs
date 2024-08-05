using AutoMapper;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Areas.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;
public class ListAreasQueryService : IListAreasQueryService
{
  private readonly AppDbContext _dbContext;
  private readonly IMapper _mapper;
  public ListAreasQueryService(AppDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }
  public async Task<IEnumerable<AreaDTO>> ListAsync(int skip, int take, CancellationToken ctx)
  {
    var result = await _dbContext.Areas.Skip(skip).Take(take).ToArrayAsync();
    return _mapper.Map<IEnumerable<AreaDTO>>(result);
  }
}
