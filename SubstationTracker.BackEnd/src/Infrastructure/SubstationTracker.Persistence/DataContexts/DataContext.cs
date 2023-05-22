using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Domain.Abstractions.Audits;
using SubstationTracker.Domain.Concrete.Products;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;
using SubstationTracker.Domain.Concrete.Sectors;
using SubstationTracker.Domain.Concrete.Substations._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;

namespace SubstationTracker.Persistence.DataContexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Audit> Audits { get; set; }
    public DbSet<CreateAudit> CreateAudits { get; set; }
    public DbSet<UpdateAudit> UpdateAudits { get; set; }
    public DbSet<DeleteAudit> DeleteAudits { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<UserVerification> UserVerifications { get; set; }
    public DbSet<UserResetPassword> UserResetPasswords { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }


    public DbSet<Sector> Sectors { get; set; }

    public DbSet<Substation> Substations { get; set; }
    public DbSet<SubstationSector> SubstationSectors { get; set; }
    public DbSet<SubstationResponsibleUser> SubstationResponsibleUsers { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSector> ProductSectors { get; set; }

    public DbSet<SubstationMovement> SubstationMovements { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryEntry> InventoryEntries { get; set; }
    public DbSet<InventoryOut> InventoryOuts { get; set; }
}