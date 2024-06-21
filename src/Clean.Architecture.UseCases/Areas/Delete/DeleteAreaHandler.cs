using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Services;
using Clean.Architecture.UseCases.Areas.Delete;

namespace Clean.Architecture.UseCases.Areas.Create;
public class DeleteAreaHandler : ICommandHandler<DeleteAreaCommand, Result>
{
  private readonly IDeleteAreaService _deleteAreaService;
  public DeleteAreaHandler(IDeleteAreaService deleteAreaService)
  {
    _deleteAreaService = deleteAreaService;
  }

  public async Task<Result> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
  {
    return await _deleteAreaService.DeleteArea(request.areaId);
  }
}
