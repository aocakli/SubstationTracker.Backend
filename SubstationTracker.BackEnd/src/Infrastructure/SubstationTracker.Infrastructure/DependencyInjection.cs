using SubstationTracker.Application.Features.Notifications.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubstationTracker.Infrastructure.Options;
using SubstationTracker.Infrastructure.Services.Notifications.Emails;

namespace SubstationTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, EmailNotificationService>();

        var configuration = services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<IConfiguration>();

        services.Configure<EmailSettingOption>(configuration.GetSection("EmailSettings"));

        return services;
    }
}