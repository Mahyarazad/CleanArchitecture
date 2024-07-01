using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Areas.List;
public record ListAreasQuery(int skip, int take) : IQuery<Result<IEnumerable<AreaDTO>>>
{
}
