using FastEndpoints;
using MediatR;
using Clean.Architecture.UseCases.Areas.Create;

namespace Clean.Architecture.Web.Areas;

public class Create(IMediator _mediator) : Endpoint<CreateAreaRequest, CreateAreaResponse>
{
  public override void Configure()
  {
    Post(CreateAreaRequest.Route);
    AllowAnonymous();

  }

  public override async Task HandleAsync(CreateAreaRequest request, CancellationToken ctx)
  {
    var result = await _mediator.Send(new CreateAreaCommand(request.AreaName!, request.AreaDisplayName, request.CityId), ctx);
    if (result.IsSuccess)
    {
      Response = new CreateAreaResponse(result.Value, request.AreaName);
      return;
    }
  }
}
