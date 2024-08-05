using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Clean.Architecture.UseCases.Cities.Get;

namespace Clean.Architecture.Web.Cities;

public class GetById : Endpoint<GetCityByIdRequest, CityRecord>
{
  private readonly IMediator _mediator;
  private readonly AutoMapper.IMapper _mapper;

  public GetById(IMediator mediator, AutoMapper.IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  public override void Configure()
  {
    Get(GetCityByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetCityByIdRequest req, CancellationToken ct)
  {
    var query = new GetCityQuery(req.CityId);
    var result = await _mediator.Send(query, ct);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    if (result.IsSuccess)
    {
      Response = _mapper.Map<CityRecord>(result.Value);
    }

  }
}
