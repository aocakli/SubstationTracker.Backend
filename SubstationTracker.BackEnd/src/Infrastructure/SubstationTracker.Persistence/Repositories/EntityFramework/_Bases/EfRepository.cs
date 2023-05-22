using Microsoft.EntityFrameworkCore;
using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

public class EfRepository<T> where T : class, IEntity
{
    protected readonly DbContext DbContext;
    protected readonly DbSet<T> Table;
    protected readonly string TableName;
    public EfRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        Table = DbContext.Set<T>();
        TableName = GetTableName();
    }
    
    private string GetTableName()
    {
        var entityTypes = DbContext.Model.GetEntityTypes();

        var clrEntity = entityTypes.FirstOrDefault(_entityType => _entityType.ClrType == typeof(T));

        var tableName = clrEntity.GetAnnotation("Relational:TableName");

        return tableName.Value.ToString();
    }
}