using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Application.Repositories._Bases;

public interface IWriteRepositoryWithSoftDelete<T> : IWriteRepository<T>
    where T : IEntity, ISoftDelete
{
    Task SoftDeleteAsync(T entity);
}