

using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Cities;
using Clean.Architecture.UseCases.Cities.Create;
using Clean.Architecture.Web.Cities;


namespace Clean.Architecture.Web.Profiles;
internal class CityProfile : Profile
{
  public CityProfile()
  {
    CreateMap<CreateCityCommand, City>();
    CreateMap<City, CityDTO>();
    CreateMap<CityDTO, CityRecord>();
  }
}
