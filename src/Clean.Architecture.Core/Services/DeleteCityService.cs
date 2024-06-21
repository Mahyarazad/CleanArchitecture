using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.Core.CityAggregate.Events;
using Clean.Architecture.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.Services;

public interface IDeleteCityService
{
  public Task<Result> DeleteCity(int cityId);
}
public class DeleteCityService(IRepository<City> _repository, IMediator _mediator,ILogger<DeleteCityService> _logger) : IDeleteCityService
{
  public async Task<Result> DeleteCity(int cityId)
  {
    _logger.LogInformation("Deleting City {cityId}", cityId);
    var aggregateToDelete = await _repository.GetByIdAsync(cityId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    //I have added this event and published it; however, I didn't add the handler, like contributor Handler.
    //We can add the INotificationHandler for the city and area deletion and send out emails or publish notifications to the admin user or other users.
    var domainEvent = new CityDeletedEvent(cityId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
