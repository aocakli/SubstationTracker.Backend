using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Application.Repositories._Bases;

public interface IWriteRepository<T> where T : IEntity
{
    public Task<T> CreateAsync(T entity);

    public Task<IEnumerable<T>> CreateBulkAsync(IEnumerable<T> entities);

    public Task UpdateAsync(T entity);
    public Task HardDeleteAsync(T entity);
    public Task<bool> SaveChangesAsync();
}