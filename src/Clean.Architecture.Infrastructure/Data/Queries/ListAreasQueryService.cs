using Clean.Architecture.Infrastructure.Data.Extensions;
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
    return await _dbContext.Areas.Include(x => x.City)
      .ApplySorting()
      .ApplyPagination(skip, take)
      .Execute(ctx);
  }
}
