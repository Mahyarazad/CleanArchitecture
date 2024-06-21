using Ardalis.Result;
using System.Threading;
using Clean.Architecture.UseCases.Cities.Get;
using FastEndpoints;
using MediatR;
using Clean.Architecture.Web.Contributors;

namespace Clean.Architecture.Web.Cities;

public class GetById(IMediator mediator) : Endpoint<GetCityByIdRequest, CityRecord>
{
  public override void Configure()
  {
    Get(GetCityByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetCityByIdRequest req, CancellationToken ct)
  {
    var query = new GetCityQuery(req.CityId);
    var result = await mediator.Send(query, ct);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new CityRecord(result.Value.id, result.Value.cityName, result.Value.cityDisplayName, result.Value.areaDto?.Select(x=> new Areas.AreaRecord(x.id, x.areaName, x.areaDisplayName, null, null)));
    }

  }
}
