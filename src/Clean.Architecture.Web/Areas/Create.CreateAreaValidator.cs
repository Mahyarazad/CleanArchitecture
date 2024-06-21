using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Clean.Architecture.Web.Areas;

public class CreateAreaResponse(int id, string areaName)
{
  public int Id { get; set; } = id;
  public string AreaName { get; set; } = areaName;
}
