using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Areas.Create;
public record CreateAreaCommand(string areaName, string? areaDisplayName, int? cityId) : ICommand<Result<int>>
{
}
