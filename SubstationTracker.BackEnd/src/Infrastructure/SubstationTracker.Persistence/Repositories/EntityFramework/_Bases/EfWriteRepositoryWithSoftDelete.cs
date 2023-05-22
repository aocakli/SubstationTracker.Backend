using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

public class EfWriteRepositoryWithSoftDelete<T> : EfWriteRepository<T>, IWriteRepositoryWithSoftDelete<T>
    where T : class, IEntity, ISoftDelete
{
    public EfWriteRepositoryWithSoftDelete(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task SoftDeleteAsync(T entity)
    {
        entity.IsDeleted = true;

        await base.UpdateAsync(entity);
    }
}