using Clean.Architecture.Core.CityAggregate;
using Clean.Architecture.UseCases.Areas;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Extensions;
public static class AreasQueryExtension
{
  public static IQueryable<Area> ApplyFilter(this IQueryable<Area> query, string title)
  {
    return query.Where(x => x.AreaName.Contains(title, StringComparison.OrdinalIgnoreCase));
  }

  public static IQueryable<Area> ApplyPagination(this IQueryable<Area> query, int skip, int take)
  {
    return query.Skip(skip).Take(take);
  }

  public static IOrderedQueryable<Area> ApplySorting(this IQueryable<Area> query)
  {
    return query.OrderByDescending(x => x.Id);
  }

  public static async Task<List<AreaDTO>> Execute(this IQueryable<Area> query, CancellationToken ctx)
  {
    return await query.Select(x => new AreaDTO(x.Id, x.AreaName, x.AreaDisplayName, x.CityId, x.City != null ? new CityDTO(x.City.Id!, x.City.CityName, x.City.CityDisplayName, null) : null))
      .ToListAsync(ctx);
  }
}
