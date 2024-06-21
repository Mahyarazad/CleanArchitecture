using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Areas.Update;

namespace Clean.Architecture.UseCases.Areas.Update;

public class UpdateAreaHandler(IRepository<Area> _repository): ICommandHandler<UpdateAreaCommand, Result<AreaDTO>>
{
  public async Task<Result<AreaDTO>> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
  {
    var existingArea = await _repository.GetByIdAsync(request.areaId, cancellationToken);
    if (existingArea == null)
    {
      return Result.NotFound();
    }

    existingArea.UpdateArea(request.newAreaName, request.newDisplayName, request.cityId);

    await _repository.UpdateAsync(existingArea, cancellationToken);

    return Result.Success(new AreaDTO(existingArea.Id, existingArea.AreaName, existingArea.AreaDisplayName, existingArea.CityId, null));
  }
}
