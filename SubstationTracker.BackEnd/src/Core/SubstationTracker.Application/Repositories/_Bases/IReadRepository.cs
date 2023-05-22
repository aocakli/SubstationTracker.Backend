using System.Linq.Expressions;
using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Repositories._Bases;

public interface IReadRepository<T> where T : class, IEntity
{
    public Task<IPaginateDataResponse<ICollection<T>>> GetAllPaginateAsync(Expression<Func<T, bool>>? exp = null,
        PaginationRequestBase? pagination = null, RepoFeatures features = default);

    public Task<HashSet<Guid>> GetIdentitiesAsync(Expression<Func<T, bool>>? exp = null,
        RepoFeatures features = default);

    public Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? exp = null, RepoFeatures features = default);

    public Task<bool> AnyAsync(Expression<Func<T, bool>> exp, RepoFeatures features = default);

    public Task<T?> GetAsync(Expression<Func<T, bool>> exp, RepoFeatures features = default);

    public Task<T?> GetByIdAsync(Guid id, RepoFeatures features = default);

    public Task<long> CountAsync(Expression<Func<T, bool>>? exp = null, RepoFeatures features = default);
}