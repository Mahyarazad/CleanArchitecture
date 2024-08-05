

using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Areas.Create;


namespace Clean.Architecture.Web.Profiles;
public class AreaProfile : Profile
{
  public AreaProfile()
    {
    CreateMap<CreateAreaCommand, Area>();
    CreateMap<AreaDTO, Area>();
    CreateMap<Area, AreaDTO>();
  }
}
