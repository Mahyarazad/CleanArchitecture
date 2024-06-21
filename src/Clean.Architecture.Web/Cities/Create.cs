using Clean.Architecture.UseCases.Areas.Create;
using Clean.Architecture.UseCases.Cities.Create;
using MediatR;

namespace Clean.Architecture.Web.Cities;

public class Create(IMediator _mediator) : FastEndpoints.Endpoint<CreateCityRequest, CreateCityResponse>
{
  public override void Configure()
  {
    Post(CreateCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateCityRequest req, CancellationToken ct)
  {
    var cityCommand = new CreateCityCommand { CityName = req.CityName, CityDisplayName = string.IsNullOrEmpty(req.CityDisplayName) ? req.CityName : req.CityDisplayName };
    if (req.Areas!= null && req.Areas.Any())
    {
      cityCommand.Areas = new List<CreateAreaCommand>();
      foreach (var item in req.Areas)
      {
        cityCommand.Areas.Add(new CreateAreaCommand(item.AreaName, item.AreaDisplayName,null));
      }
    }

    var createCityResult = await _mediator.Send(cityCommand, ct);
    if (createCityResult.IsSuccess)
    {
      Response = new CreateCityResponse(createCityResult.Value, req.CityName);
      return;
    }

  }
}
