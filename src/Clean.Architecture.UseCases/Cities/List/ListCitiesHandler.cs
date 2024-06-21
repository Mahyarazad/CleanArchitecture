using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.List;
public class ListCitiesHandler(IListCitiesQueryService _query) : IQueryHandler<ListCitiesQuery, Result<IEnumerable<CityDTO>>>
{
  public async Task<Result<IEnumerable<CityDTO>>> Handle(ListCitiesQuery request, CancellationToken cancellationToken)
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
