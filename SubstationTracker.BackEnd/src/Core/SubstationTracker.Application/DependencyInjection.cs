using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SubstationTracker.Application.BehaviorPipelines.Logs;
using SubstationTracker.Application.BehaviorPipelines.Transaction;
using SubstationTracker.Application.BehaviorPipelines.Validation;
using SubstationTracker.Application.Features.Users._Bases.BusinessRules;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Services;
using SubstationTracker.Application.Utilities.Auth;
using SubstationTracker.Application.Utilities.Extensions;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;

namespace SubstationTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddBusinessRulesDependencies(assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionScopeBehaviour<,>));

        services.AddScoped<LanguageService>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<Random>();
        services.AddScoped<RandomService>();
        services.AddScoped<AuthService>();
        services.AddSingleton<FileService>();
        services.AddScoped<RequestService>();

        return services;
    }
}