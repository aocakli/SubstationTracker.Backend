using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryEntries;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryOuts;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationSectors;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserResetPasswords;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserRoles;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserTokens;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserVerifications;
using SubstationTracker.Persistence.DataContexts;
using SubstationTracker.Persistence.Helpers;
using SubstationTracker.Persistence.Repositories.EntityFramework.Products._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework.Products.OtherRepositories.ProductSectors;
using SubstationTracker.Persistence.Repositories.EntityFramework.Sectors;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories.OtherRepositories.InventoryEntries;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories.OtherRepositories.InventoryOuts;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.
    SubstationResponsibleUsers;
using SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationSectors;
using SubstationTracker.Persistence.Repositories.EntityFramework.Users._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserLogs;
using SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserResetPasswords;
using SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserRoles;
using SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserTokens;
using SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserVerifications;

namespace SubstationTracker.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<DbContext, DataContext>(x =>
            x.Process(connectionString: configuration.GetConnectionString("PostgreSql")!));
        // services.AddDbContext<DbContext, DataContext>(x => x.Process());

        services.AddScoped<IUserReadRepository, EfUserReadRepository>();
        services.AddScoped<IUserWriteRepository, EfUserWriteRepository>();

        services.AddScoped<IUserResetPasswordReadRepository, EfUserResetPasswordReadRepository>();
        services.AddScoped<IUserResetPasswordWriteRepository, EfUserResetPasswordWriteRepository>();

        services.AddScoped<IUserRoleReadRepository, EfUserRoleReadRepository>();
        services.AddScoped<IUserRoleWriteRepository, EfUserRoleWriteRepository>();

        services.AddScoped<IUserTokenReadRepository, EfUserTokenReadRepository>();
        services.AddScoped<IUserTokenWriteRepository, EfUserTokenWriteRepository>();

        services.AddScoped<IUserVerificationReadRepository, EfUserVerificationReadRepository>();
        services.AddScoped<IUserVerificationWriteRepository, EfUserVerificationWriteRepository>();

        services.AddScoped<IUserLogReadRepository, EfUserLogReadRepository>();
        services.AddScoped<IUserLogWriteRepository, EfUserLogWriteRepository>();

        services.AddScoped<ISectorReadRepository, EfSectorReadRepository>();
        services.AddScoped<ISectorWriteRepository, EfSectorWriteRepository>();

        services.AddScoped<ISubstationReadRepository, EfSubstationReadRepository>();
        services.AddScoped<ISubstationWriteRepository, EfSubstationWriteRepository>();

        services.AddScoped<ISubstationSectorReadRepository, EfSubstationSectorReadRepository>();
        services.AddScoped<ISubstationSectorWriteRepository, EfSubstationSectorWriteRepository>();

        services.AddScoped<ISubstationResponsibleUserReadRepository, EfSubstationResponsibleUserReadRepository>();
        services.AddScoped<ISubstationResponsibleUserWriteRepository, EfSubstationResponsibleUserWriteRepository>();

        services.AddScoped<IProductReadRepository, EfProductReadRepository>();
        services.AddScoped<IProductWriteRepository, EfProductWriteRepository>();

        services.AddScoped<IProductSectorReadRepository, EfProductSectorReadRepository>();
        services.AddScoped<IProductSectorWriteRepository, EfProductSectorWriteRepository>();

        services.AddScoped<IInventoryReadRepository, EfInventoryReadRepository>();
        services.AddScoped<IInventoryWriteRepository, EfInventoryWriteRepository>();

        services.AddScoped<IInventoryEntryReadRepository, EfInventoryEntryReadRepository>();
        services.AddScoped<IInventoryEntryWriteRepository, EfInventoryEntryWriteRepository>();
        
        services.AddScoped<IInventoryOutReadRepository, EfInventoryOutReadRepository>();
        services.AddScoped<IInventoryOutWriteRepository, EfInventoryOutWriteRepository>();
        
        services.AddScoped<ISubstationMovementReadRepository, EfSubstationMovementReadRepository>();
        services.AddScoped<ISubstationMovementWriteRepository, EfSubstationMovementWriteRepository>();

        return services;
    }
}