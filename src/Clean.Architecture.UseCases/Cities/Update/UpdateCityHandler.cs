using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.Update;

public class UpdateCityHandler(IRepository<City> _repository): ICommandHandler<UpdateCityCommand, Result<CityDTO>>
{
  public async Task<Result<CityDTO>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
  {
    var existingCity = await _repository.GetByIdAsync(request.cityID, cancellationToken);
    if (existingCity == null)
    {
      return Result.NotFound();
    }

    existingCity.UpdateCity(request.newCityName, request.newDisplayName);

    await _repository.UpdateAsync(existingCity, cancellationToken);

    return Result.Success(new CityDTO(existingCity.Id, existingCity.CityName, existingCity.CityDisplayName
      , existingCity.Aera.Select(x => new AreaDTO(x.Id, x.AreaName, x.AreaDisplayName, x.CityId, null))));
  }
}
