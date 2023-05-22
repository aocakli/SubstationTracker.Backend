using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SubstationTracker.Persistence.DataContexts;
using SubstationTracker.Persistence.Helpers;

namespace SubstationTracker.Persistence.DesignTimeFactories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        if (args.Length is 0)
            throw new Exception("Please use args. Example (dotnet ef migrations add -- --environment Production)");

        string environmentName = args[1];

        if (new[] { "Production", "Development" }.Contains(args[1]) is false)
            throw new Exception(
                "Please use environment variable. (Production or Development) (dotnet ef migrations add -- --environment Production)");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../../Presentation/SubstationTracker.WebAPI/")
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("PostgreSql")!;

        return new DataContext(DbContextOptionsHelper.GetDbContextOption(connectionString: connectionString).Options);
    }
}