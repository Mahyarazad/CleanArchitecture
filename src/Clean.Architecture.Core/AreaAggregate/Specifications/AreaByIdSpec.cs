using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Clean.Architecture.Core.CityAggregate;

namespace Clean.Architecture.Core.AreaAggregate.Specifications;
public class AreaByIdSpec : Specification<Area>
{
  public AreaByIdSpec(int areaId)
  {
    Query.Where(x => x.Id == areaId);
  }
}
