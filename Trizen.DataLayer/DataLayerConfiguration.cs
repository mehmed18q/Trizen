using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.DataLayer.Repositories;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.DataLayer;
public static class DataLayerConfiguration
{
    public static void RegisterDataLayer(this IServiceCollection services)
    {
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        Assembly? registerScopedAssembly = Assembly.GetAssembly(typeof(DataLayerConfiguration));
        if (registerScopedAssembly is null)
        {
            return;
        }

        List<Type> registerScopedServices = registerScopedAssembly.GetTypes().Where(x =>
        x.IsClass && typeof(IRegisterRepositories).IsAssignableFrom(x)).ToList();

        foreach (Type? service in registerScopedServices)
        {
            Type? @interface = service.GetInterfaces().FirstOrDefault();
            if (@interface is null)
            {
                continue;
            }

            if (typeof(IRegisterRepositories).IsAssignableFrom(service))
            {
                _ = services.AddScoped(@interface, service);
            }
        }

        _ = services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
    }
}
