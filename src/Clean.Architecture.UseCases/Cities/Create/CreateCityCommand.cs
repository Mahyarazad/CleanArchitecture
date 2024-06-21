using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Areas.Create;

namespace Clean.Architecture.UseCases.Cities.Create;
public record CreateCityCommand : ICommand<Result<int>>
{
  public required string CityName { get; set; }
  public required string CityDisplayName { get; set; }
  public IList<CreateAreaCommand>? Areas { get; set; }
}
