using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Areas.Update;

public record UpdateAreaCommand(int areaId, string newAreaName, string newDisplayName, int? cityId) : ICommand<Result<AreaDTO>>;
