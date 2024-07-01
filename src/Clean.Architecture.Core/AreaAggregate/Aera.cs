using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.CityAggregate;
public class Area(string areaName, string? areaDisplayName, int? cityId) : EntityBase, IAggregateRoot
{
  public string AreaName { get; private set; } = Guard.Against.NullOrEmpty(areaName);
  public string? AreaDisplayName { get; private set; } = areaDisplayName;

  public int? CityId { get; private set; } = cityId;
  //navigation property
  public City? City { get; private set; }

  public void UpdateArea(string areaName, string? areaDisplayName, int? cityId)
  {
    AreaName = areaName;
    AreaDisplayName = areaDisplayName;
    CityId = cityId;
  }

}

