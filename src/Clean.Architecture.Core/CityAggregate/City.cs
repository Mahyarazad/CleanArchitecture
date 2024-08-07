﻿using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.CityAggregate;
public class City : EntityBase, IAggregateRoot
{
  public City(string cityName, string cityDisplayName)
  {
    CityName = Guard.Against.NullOrEmpty(cityName);
    CityDisplayName = cityDisplayName;
    // using Hashset tp prevent duplication
    Aera = new List<Area>();
  }
  public string CityName { get; private set; }
  public string? CityDisplayName { get; private set; }

  public virtual IEnumerable<Area>? Aera { get; set; }

  public void UpdateCity(string cityName, string? displayName)
  {
    CityName = cityName;
    CityDisplayName = displayName;
  }
}

