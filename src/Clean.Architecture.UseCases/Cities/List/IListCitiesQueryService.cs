using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.UseCases.Areas;
using Clean.Architecture.UseCases.Contributors;

namespace Clean.Architecture.UseCases.Cities.List;
public interface IListCitiesQueryService
{
  Task<IEnumerable<CityDTO>> ListAsync(int skip, int take, CancellationToken ctx);
}
