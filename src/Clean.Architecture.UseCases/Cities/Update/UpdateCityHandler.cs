using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Cities.Update;

public class UpdateCityHandler: ICommandHandler<UpdateCityCommand, Result<CityDTO>>
{
  private readonly IMapper _mapper;
  private readonly IRepository<City> _repository;
  public UpdateCityHandler(IMapper mapper, IRepository<City> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }
  public async Task<Result<CityDTO>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
  {
    var existingCity = await _repository.GetByIdAsync(request.cityID, cancellationToken);
    if (existingCity == null)
    {
      return Result.NotFound();
    }

    existingCity.UpdateCity(request.newCityName, request.newDisplayName);

    await _repository.UpdateAsync(existingCity, cancellationToken);

    return Result.Success(_mapper.Map<CityDTO>(existingCity));
  }
}
