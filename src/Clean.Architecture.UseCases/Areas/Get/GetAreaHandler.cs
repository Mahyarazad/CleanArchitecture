using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using Clean.Architecture.Core.AreaAggregate.Specifications;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.UseCases.Areas.Get;
public class GetAreaHandler(IReadRepository<Area> readRepository, IMapper _mapper) : IQueryHandler<GetAreaQuery, Result<AreaDTO>>
{

  public async Task<Result<AreaDTO>> Handle(GetAreaQuery request, CancellationToken cancellationToken)
  {
    var spec = new AreaByIdSpec(request.areaId);
    var entity = await readRepository.FirstOrDefaultAsync(spec, cancellationToken);
    if(entity is null)
    {
      return Result.NotFound();
    }

    return _mapper.Map<AreaDTO>(entity);  

    //return new AreaDTO(entity.Id, entity.AreaName, entity.AreaDisplayName, entity.CityId, entity.City != null ? new CityDTO(entity.City.Id, entity.City.CityName, entity.City.CityDisplayName, null) : null );
  }
}
