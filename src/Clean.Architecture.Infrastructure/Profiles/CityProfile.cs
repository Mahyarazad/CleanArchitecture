using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Cities;

namespace Clean.Architecture.Infrastructure.Profiles;
internal class CityProfile : Profile
{
  public CityProfile()
  {
    CreateMap<City, CityDTO>();
  }
}
