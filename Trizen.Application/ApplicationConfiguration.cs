using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application;
public static class ApplicationConfiguration
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddAutoMapper();
        services.AddServices();
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        MapperConfiguration config = new(cfg =>
        {
            Assembly? registerMapperAssembly = Assembly.GetAssembly(typeof(ApplicationConfiguration));
            if (registerMapperAssembly is null)
            {
                return;
            }

            List<Type> registerMapperProfiles = registerMapperAssembly.GetTypes().Where(x => x.IsClass && typeof(IRegisterMappers).IsAssignableFrom(x)).ToList();

            foreach (Type? mapper in registerMapperProfiles)
            {
                if (typeof(IRegisterMappers).IsAssignableFrom(mapper))
                {
                    if (Activator.CreateInstance(mapper) is Profile profileInstance)
                    {
                        cfg.AddProfile(profileInstance);
                    }
                }
            }
        });
        IMapper mapper = config.CreateMapper();
        _ = services.AddSingleton(mapper);
    }

    private static void AddServices(this IServiceCollection services)
    {
        Assembly? registerScopedAssembly = Assembly.GetAssembly(typeof(ApplicationConfiguration));
        if (registerScopedAssembly is null)
        {
            return;
        }

        List<Type> registerScopedServices = registerScopedAssembly.GetTypes().Where(x => x.IsClass && (typeof(IRegisterServices).IsAssignableFrom(x) || typeof(IRegisterHttpClient).IsAssignableFrom(x))).ToList();

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
