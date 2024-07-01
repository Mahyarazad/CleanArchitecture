using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.UseCases.Areas.Create;
public class CreateAreaHandler : ICommandHandler<CreateAreaCommand, Result<int>>
{
  private readonly IRepository<Area> _repository;
  private readonly IMapper _mapper;
  public CreateAreaHandler(IRepository<Area> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }
  public async Task<Result<int>> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
  {
    var newrarea = _mapper.Map<Area>(request);
    var createdItem = await _repository.AddAsync(newrarea, cancellationToken);
    return createdItem.Id;
  }
}
