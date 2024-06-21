using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.AreaAggregate.Events;
using Clean.Architecture.Core.CityAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.Services;
public interface IDeleteAreaService
{
  public Task<Result> DeleteArea(int areaId);
}
public class DeleteAreaService(IRepository<Area> _repository, IMediator _mediator,ILogger<DeleteAreaService> _logger) : IDeleteAreaService
{
  public async Task<Result> DeleteArea(int areaId)
  {
    _logger.LogInformation("Deleting Area {areaId}", areaId);
    var aggregateToDelete = await _repository.GetByIdAsync(areaId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    //I have added this event and published it; however, I didn't add the handler, like contributor Handler.
    //We can add the INotificationHandler for the city and area deletion and send out emails or publish notifications to the admin user or other users.
    var domainEvent = new AreaDeletedEvent(areaId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
