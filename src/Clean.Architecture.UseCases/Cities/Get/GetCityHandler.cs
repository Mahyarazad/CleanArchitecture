using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.Core.CityAggregate.Specifications;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.Get;
public class GetCityHandler : IQueryHandler<GetCityQuery, Result<CityDTO>>
{
  private readonly IReadRepository<City> _readRepository;
  private readonly IMapper _mapper;
  public GetCityHandler(IReadRepository<City> readRepository, IMapper mapper)
  {
    _readRepository = readRepository;
    _mapper = mapper;
  }
  public async Task<Result<CityDTO>> Handle(GetCityQuery request, CancellationToken cancellationToken)
  {
    var spec = new CityByIdSpec(request.cityId);
    var entity = await _readRepository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity is null)
    {
      return Result.NotFound();
    }

    return _mapper.Map<CityDTO>(entity);
    //return new CityDTO(entity.Id, entity.CityName, entity.CityDisplayName, entity.Aera?.Select(x=> new AreaDTO(x.Id, x.AreaName, x.AreaDisplayName, null, null)));
  }
}
