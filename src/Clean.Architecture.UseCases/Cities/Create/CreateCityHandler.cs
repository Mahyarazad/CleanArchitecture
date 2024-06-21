using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.UseCases.Cities.Create;
public class CreateCityHandler : ICommandHandler<CreateCityCommand, Result<int>>
{
  private readonly IRepository<City> _cityRepository;
  private readonly IRepository<Area> _areaRepository;
  public CreateCityHandler(IRepository<City> cityRepository, IRepository<Area> areaRepository)
  {
    _cityRepository = cityRepository;
    _areaRepository = areaRepository;
  }

  public async Task<Result<int>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
  {
    // I guess we can use auto mapper here to simplify mapping between DTOs and entities
    var newCity = new City(request.CityName, request.CityDisplayName);
    var createdItem = await _cityRepository.AddAsync(newCity, cancellationToken);
    if (request.Areas != null && request.Areas.Any())
    {
      var areas = new List<Area>();
      foreach (var area in request.Areas)
      {
        areas.Add(new Area(area.areaName, area.areaDisplayName, createdItem.Id));
      }
      await _areaRepository.AddRangeAsync(areas, cancellationToken);
    }

    return createdItem.Id;
  }
}
