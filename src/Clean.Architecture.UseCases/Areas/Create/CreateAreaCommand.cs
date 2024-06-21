using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Areas.Create;
public record CreateAreaCommand(string areaName, string? areaDisplayName, int? cityId) : ICommand<Result<int>>
{
}
