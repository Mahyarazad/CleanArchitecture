using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.AreaAggregate.Specifications;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.UseCases.Areas.Get;
public class GetAreaHandler(IReadRepository<Area> readRepository) : IQueryHandler<GetAreaQuery, Result<AreaDTO>>
{
  public async Task<Result<AreaDTO>> Handle(GetAreaQuery request, CancellationToken cancellationToken)
  {
    var spec = new AreaByIdSpec(request.areaId);
    var entity = await readRepository.FirstOrDefaultAsync(spec, cancellationToken);
    if(entity is null)
    {
      return Result.NotFound();
    }

    return new AreaDTO(entity.Id, entity.AreaName, entity.AreaDisplayName, entity.CityId, entity.City != null ? new CityDTO(entity.City.Id, entity.City.CityName, entity.City.CityDisplayName, null) : null );
  }
}
