using Ardalis.Result;
using Clean.Architecture.UseCases.Cities;
using Clean.Architecture.UseCases.Cities.List;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Cities;

public class List(IMediator _mediator) : Endpoint<CityListRequest,CityListResponse>
{
  public override void Configure()
  {
    Get(CityListRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CityListRequest req,CancellationToken cancellationToken)
  {
    Result<IEnumerable<CityDTO>> result = await _mediator.Send(new ListCitiesQuery(req.Skip, req.Take), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CityListResponse
      {
        Cities = result.Value.ToList()
      };
    }
  }
}
