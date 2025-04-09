using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trizen.DataLayer;
using Trizen.Infrastructure.Base;

namespace Trizen.Presentation;
public static class PresentationConfiguration
{
    public static void RegisterPresentation(this IServiceCollection services, IConfigurationManager configuration, ILoggingBuilder logging)
    {
        _ = services.AddConfigurations(configuration);
        _ = services.AddDatabase(configuration);
        _ = services.AddLog(configuration, logging);
        _ = services.AddIdentity();
    }

    private static IServiceCollection AddConfigurations(this IServiceCollection services, IConfigurationManager configuration)
    {
        _ = services.AddOptions();
        _ = services.Configure<TrizenConfiguration>(configuration.GetSection(nameof(TrizenConfiguration)));

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfigurationManager configuration)
    {
        string connectionString = configuration.GetConnectionString("TrizenConnection") ?? throw new InvalidOperationException("Connection string 'TrizenConnection' not found.");

        _ = services.AddDbContext<TrizenDbContext>(options =>
        {
            _ = options.UseSqlServer(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddLog(this IServiceCollection services, IConfigurationManager configuration, ILoggingBuilder logging)
    {
        try
        {
            Serilog.Core.Logger logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            _ = logging.ClearProviders();
            _ = logging.AddSerilog(logger);
        }
        catch (Exception) { }

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        _ = services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

        _ = services.AddAuthorization();

        return services;
    }
}
