using System.Linq;
using Ardalis.Result;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Cities.List;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Areas;

public class List(IMediator _mediator) : Endpoint<AreaListRequest,AreaListResponse>
{
  public override void Configure()
  {
    Get(AreaListRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(AreaListRequest req,CancellationToken cancellationToken)
  {
    Result<IEnumerable<AreaDTO>> result = await _mediator.Send(new ListAreasQuery(req.Skip, req.Take), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new AreaListResponse
      {
        Areas = result.Value.ToList()
      };
    }
  }
}
