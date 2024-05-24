using Infrastructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;

namespace Infrastructure.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        c => c.MigrationsHistoryTable("__migrations_history", Schemas.Api))
                    .UseSnakeCaseNamingConvention()
            );

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<PublishDomainEventsInterceptor>();

        return services;
    }
}