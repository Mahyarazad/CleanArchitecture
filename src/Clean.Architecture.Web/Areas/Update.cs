using Ardalis.Result;
using Clean.Architecture.UseCases.Areas.Get;
using Clean.Architecture.UseCases.Areas.Update;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Areas;

public class Update(IMediator _mediator): Endpoint<UpdateAreaRequest, UpdateAreaResponse>
{
  public override void Configure()
  {
    Put(UpdateAreaRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdateAreaRequest request,CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateAreaCommand(request.Id, request.AreaName!, request.DisplayAreaName!, request.CityId), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetAreaQuery(request.AreaId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      Response = new UpdateAreaResponse(new AreaRecord(queryResult.Value.id, queryResult.Value.areaName, queryResult.Value.areaDisplayName, queryResult.Value.cityID,null));
      return;
    }
  }
}
