using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.CityAggregate.Events;

internal sealed class CityDeletedEvent(int cityId) : DomainEventBase
{
  public int CityId { get; init; } = cityId;
}
