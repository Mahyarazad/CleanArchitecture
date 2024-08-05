using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.UseCases;
internal static class ServiceExtension
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
  {
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    return services;
  }
}
