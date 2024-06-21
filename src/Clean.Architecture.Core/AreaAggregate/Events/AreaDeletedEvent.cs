using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.AreaAggregate.Events;

internal sealed class AreaDeletedEvent(int areaId) : DomainEventBase
{
  public int AreaId { get; init; } = areaId;
}
