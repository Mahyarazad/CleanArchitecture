using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Cities.Delete;
public record DeleteCityCommand(int cityId) : ICommand<Result>
{
}
