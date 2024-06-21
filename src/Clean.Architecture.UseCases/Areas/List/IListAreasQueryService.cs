namespace Clean.Architecture.UseCases.Areas.List;
public interface IListAreasQueryService
{
  Task<IEnumerable<AreaDTO>> ListAsync(int skip, int take, CancellationToken ctx);
}
