using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Clean.Architecture.Web.Cities;
using Clean.Architecture.UseCases.Areas.Get;
using AutoMapper;

namespace Clean.Architecture.Web.Areas;

public class GetById : Endpoint<GetAreaByIdRequest, AreaRecord>
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
    Get(GetAreaByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetAreaByIdRequest request, CancellationToken ctx)
  {
    var query = new GetAreaQuery(request.AreaId);
    var result = await _mediator.Send(query, ctx);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ctx);
      return;
    }

    if (result.IsSuccess)
    {
      var area = result.Value;
      Response = _mapper.Map<AreaRecord>(area);
    }
  }
}
