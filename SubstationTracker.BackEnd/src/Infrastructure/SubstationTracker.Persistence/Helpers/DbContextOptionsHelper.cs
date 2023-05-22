using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SubstationTracker.Persistence.DataContexts;

namespace SubstationTracker.Persistence.Helpers;

public static class DbContextOptionsHelper
{
    public static DbContextOptionsBuilder GetDbContextOption(string connectionString,
        DbContextOptionsBuilder? opt = null)
    {
        opt ??= new DbContextOptionsBuilder();

        opt.UseNpgsql(connectionString);
        opt.EnableSensitiveDataLogging();

        return opt;
    }

    public static DbContextOptionsBuilder Process(this DbContextOptionsBuilder opt, string connectionString)
    {
        return GetDbContextOption(connectionString, opt);
    }
}