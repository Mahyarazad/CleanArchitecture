using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Areas.Delete;
public record DeleteAreaCommand(int areaId) : ICommand<Result>
{
}
