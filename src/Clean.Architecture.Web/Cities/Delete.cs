using Ardalis.Result;
using Clean.Architecture.UseCases.Areas.Delete;
using Clean.Architecture.UseCases.Cities.Delete;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Cities;

public class Delete(IMediator _mediator) : Endpoint<DeleteCityRequest>
{
  public override void Configure()
  {
    Delete(DeleteCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteCityRequest request, CancellationToken ctx)
  {
    var command = new DeleteCityCommand(request.CityId);
    try
    {
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

    }catch(Exception ex)
    {
       while(ex.InnerException !=  null)
      {
        ex = ex.InnerException;
      }
      await SendStringAsync(ex.Message, 400);
    }
  }
}
