using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Cities.List;

namespace Clean.Architecture.UseCases.Areas.List;
public class ListAreasHandler(IListAreasQueryService _query) : IQueryHandler<ListAreasQuery, Result<IEnumerable<AreaDTO>>>
{
  public async Task<Result<IEnumerable<AreaDTO>>> Handle(ListAreasQuery request, CancellationToken cancellationToken)
  {
    try
    {
      var result = await _query.ListAsync(request.skip, request.take, cancellationToken);
      return Result.Success(result);

    }
    catch(Exception ex) 
    {
      while(ex.InnerException != null)
      {
        ex = ex.InnerException;
      }

      return Result.CriticalError(ex.Message);
    }
  }
}
