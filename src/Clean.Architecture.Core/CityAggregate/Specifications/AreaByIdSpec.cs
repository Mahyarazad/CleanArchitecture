using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.Core.CityAggregate.Specifications;
public class CityByIdSpec : Specification<City>
{
  public CityByIdSpec(int cityId)
  {
    Query.Include(x=> x.Aera).Where(x => x.Id == cityId);
  }
}
