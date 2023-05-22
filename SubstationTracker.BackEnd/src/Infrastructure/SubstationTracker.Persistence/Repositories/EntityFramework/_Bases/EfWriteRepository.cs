using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

public class EfWriteRepository<T> : EfRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    public EfWriteRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        await Table.AddAsync(entity);

        return entity;
    }

    public virtual async Task<IEnumerable<T>> CreateBulkAsync(IEnumerable<T> entities)
    {
        var bulkEntities = entities.ToList();
        await Table.AddRangeAsync(bulkEntities);
        return bulkEntities;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        await Task.FromResult(Table.Update(entity));
    }

    public virtual async Task HardDeleteAsync(T entity)
    {
        await Task.FromResult(Table.Remove(entity));
    }

    public virtual async Task<bool> SaveChangesAsync()
    {
        return await base.DbContext.SaveChangesAsync() > 0;
    }
}