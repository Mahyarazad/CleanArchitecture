using Ardalis.Result;
using Clean.Architecture.UseCases.Cities.Get;
using Clean.Architecture.UseCases.Cities.Update;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Cities;

public class Update(IMediator _mediator): Endpoint<UpdateCityRequest, UpdateCityResponse>
{
  public override void Configure()
  {
    Put(UpdateCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdateCityRequest request,CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateCityCommand(request.Id, request.CityName!, request.DisplayCityName!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetCityQuery(request.CityId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      Response = new UpdateCityResponse(new CityRecord(queryResult.Value.id, queryResult.Value.cityName, queryResult.Value.cityDisplayName, 
        queryResult.Value.areaDto!.Select(x=> new Areas.AreaRecord(x.id, x.areaName, x.areaDisplayName, x.cityID, null))));
      return;
    }
  }
}
