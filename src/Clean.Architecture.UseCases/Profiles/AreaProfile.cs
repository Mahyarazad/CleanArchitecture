using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;

namespace Clean.Architecture.UseCases.Profiles;
internal class AreaProfile : Profile
{
  public AreaProfile()
  {
    CreateMap<Area, AreaDTO>();
  }
}
