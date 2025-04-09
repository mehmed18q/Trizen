using Microsoft.Extensions.DependencyInjection;
using Trizen.Infrastructure.Dapper;
using Trizen.Infrastructure.Utilities;

namespace Trizen.Infrastructure;
public static class InfrastructureConfiguration
{
    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddInfrastructureUtility();
    }

    public static void AddInfrastructureUtility(this IServiceCollection services)
    {
        _ = services.AddSingleton<RedisCacheUtility>();
        _ = services.AddScoped(typeof(IDapperService<,>), typeof(DapperService<,>));
    }
}
