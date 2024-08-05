using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Cities;

namespace Clean.Architecture.UseCases.Profiles;
internal class CityProfile : Profile
{
  public CityProfile()
  {
    CreateMap<City, CityDTO>().ConstructUsing(x=> new CityDTO(x.Id, x.CityName, x.CityDisplayName, 
                x.Aera!.Select(a=> new AreaDTO(a.Id, a.AreaName, a.AreaDisplayName, x.Id, null))));
  }
}
