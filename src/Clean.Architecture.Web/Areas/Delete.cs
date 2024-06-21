using Ardalis.Result;
using Clean.Architecture.UseCases.Areas.Delete;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Areas;

public class Delete(IMediator _mediator) : Endpoint<DeleteAreaRequest>
{
  public override void Configure()
  {
    Delete(GetAreaByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteAreaRequest request, CancellationToken ctx)
  {
    var command = new DeleteAreaCommand(request.AreaId);
    var result = await _mediator.Send(command, ctx);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ctx);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(ctx);
    };
  }
}
