using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Services;

namespace Clean.Architecture.UseCases.Cities.Delete;
public class DeleteCityHandler : ICommandHandler<DeleteCityCommand, Result>
{
  private readonly IDeleteCityService _deleteCityService;
  public DeleteCityHandler(IDeleteCityService deleteCityService)
  {
    _deleteCityService = deleteCityService;
  }
  public async Task<Result> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
  {
    return await _deleteCityService.DeleteCity(request.cityId);
  }
}
