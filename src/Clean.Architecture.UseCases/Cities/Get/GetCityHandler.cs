using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.Core.CityAggregate.Specifications;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.Get;
public class GetCityHandler(IReadRepository<City> readRepository) : IQueryHandler<GetCityQuery, Result<CityDTO>>
{
  public async Task<Result<CityDTO>> Handle(GetCityQuery request, CancellationToken cancellationToken)
  {
    var spec = new CityByIdSpec(request.cityId);
    var entity = await readRepository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity is null)
    {
      return Result.NotFound();
    }

    return new CityDTO(entity.Id, entity.CityName, entity.CityDisplayName, entity.Aera?.Select(x=> new AreaDTO(x.Id, x.AreaName, x.AreaDisplayName, null, null)));
  }
}
