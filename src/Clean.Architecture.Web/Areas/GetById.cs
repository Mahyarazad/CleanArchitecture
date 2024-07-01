using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Clean.Architecture.Web.Cities;
using Clean.Architecture.UseCases.Areas.Get;

namespace Clean.Architecture.Web.Areas;

public class GetById(IMediator mediator) : Endpoint<GetAreaByIdRequest, AreaRecord>
{
  public override void Configure()
  {
    Get(GetAreaByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetAreaByIdRequest request, CancellationToken ctx)
  {
    var query = new GetAreaQuery(request.AreaId);
    var result = await mediator.Send(query, ctx);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ctx);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new AreaRecord(result.Value.id, result.Value.areaName, result.Value.areaDisplayName,result.Value.cityID
        , result.Value.city != null ? new CityRecord(result.Value.city.Value.id, result.Value.city.Value.cityName, result.Value.city.Value.cityDisplayName, null) : null);
    }
  }
}
