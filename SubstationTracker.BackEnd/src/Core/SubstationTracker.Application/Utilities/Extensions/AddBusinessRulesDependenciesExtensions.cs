using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SubstationTracker.Application.Abstracts;

namespace SubstationTracker.Application.Utilities.Extensions;

public static class AddBusinessRulesDependenciesExtension
{
    public static void AddBusinessRulesDependencies(this IServiceCollection services, Assembly assembly)
    {
        var businessRulesTypes = assembly.GetTypes()
            .Where(_type => _type.IsClass && typeof(IBusinessRules).IsAssignableFrom(_type));

        foreach (var type in businessRulesTypes)
        {
            services.AddScoped(type);
        }
    }
}