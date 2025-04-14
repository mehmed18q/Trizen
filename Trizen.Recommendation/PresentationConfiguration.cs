using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Recommendation;
public static class PresentationConfiguration
{
    public static void RegisterPresentation(this IServiceCollection services)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        Assembly? registerScopedAssembly = Assembly.GetAssembly(typeof(PresentationConfiguration));
        if (registerScopedAssembly is null)
        {
            return;
        }

        List<Type> registerScopedServices = registerScopedAssembly.GetTypes().Where(x => x.IsClass && typeof(IRegisterServices).IsAssignableFrom(x)).ToList();

        foreach (Type? service in registerScopedServices)
        {
            Type? @interface = service.GetInterfaces().FirstOrDefault();
            if (@interface is null)
            {
                continue;
            }

            if (typeof(IRegisterServices).IsAssignableFrom(service))
            {
                _ = services.AddScoped(@interface, service);
            }
        }
    }
}
