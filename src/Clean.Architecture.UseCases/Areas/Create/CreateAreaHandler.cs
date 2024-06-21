using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.UseCases.Areas.Create;
public class CreateAreaHandler : ICommandHandler<CreateAreaCommand, Result<int>>
{
  private readonly IRepository<Area> _repository;
  public CreateAreaHandler(IRepository<Area> repository)
  {
    _repository = repository;
  }
  public async Task<Result<int>> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
  {
    // I guess we can use auto mapper here to simplify mapping between DTOs and entities
    var newrarea = new Area(request.areaName, request.areaDisplayName, request.cityId);
    var createdItem = await _repository.AddAsync(newrarea, cancellationToken);
    return createdItem.Id;
  }
}
