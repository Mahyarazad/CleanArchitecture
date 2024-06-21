using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.Update;

public record UpdateCityCommand(int cityID, string newCityName, string newDisplayName) : ICommand<Result<CityDTO>>;
