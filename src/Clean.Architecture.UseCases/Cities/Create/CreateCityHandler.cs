using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.UseCases.Cities.Create;
public class CreateCityHandler : ICommandHandler<CreateCityCommand, Result<int>>
{
  private readonly IRepository<City> _cityRepository;
  private readonly IRepository<Area> _areaRepository;
  private readonly IMapper _mapper;

  public CreateCityHandler(IRepository<City> cityRepository, IRepository<Area> areaRepository, IMapper mapper)
  {
    _cityRepository = cityRepository;
    _areaRepository = areaRepository;
    _mapper = mapper;
  }

  public async Task<Result<int>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
  {

    var newCity = _mapper.Map<City>(request);
    var createdItem = await _cityRepository.AddAsync(newCity, cancellationToken);
    if (request.Areas != null && request.Areas.Any())
    {
      var areas = new List<Area>();
      foreach (var area in newCity.Aera)
      {
        areas.Add(area);
      }
      await _areaRepository.AddRangeAsync(areas, cancellationToken);
    }

    return createdItem.Id;
  }
}
