namespace Clean.Architecture.Web.Areas;

public class UpdateAreaResponse(AreaRecord area)
{
  public AreaRecord Area { get; set; } = area;
}
