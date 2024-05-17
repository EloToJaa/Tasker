using Application.Common.Interfaces.Persistance;
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
                    .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention()
            );

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<PublishDomainEventsInterceptor>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}