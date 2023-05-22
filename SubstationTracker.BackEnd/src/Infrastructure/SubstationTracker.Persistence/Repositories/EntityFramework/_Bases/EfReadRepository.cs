using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;
using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

public class EfReadRepository<T> : EfRepository<T>, IReadRepository<T> where T : class, IEntity
{
    public EfReadRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected IQueryable<T> Query(RepoFeatures features)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (features.IgnoreQueryFilters)
            query = query.IgnoreQueryFilters();

        if (features.IncludeAudit)
        {
            var isEntityHaveAudit = typeof(T).GetInterfaces().Any(x => x == typeof(IHistoryEntity));

            if (isEntityHaveAudit)
            {
                query = query.Include("Audit");
                query = query.Include("Audit.CreateAudit");
                query = query.Include("Audit.UpdateAudits");
            }
        }

        if (features.NoTracking)
            query = query.AsTracking();

        return query;
    }

    protected IQueryable<TReturn> ProcessPaginate<TReturn>(IQueryable<TReturn> query, PaginationRequestBase pagination)
    {
        query = query.Skip((pagination.Page - 1) * pagination.ItemCount ?? 0);

        if (pagination.ItemCount.HasValue)
            query = query.Take(pagination.ItemCount.Value);

        return query;
    }

    protected async Task<IPaginateDataResponse<ICollection<TType>>> PaginateAsync<TType>(IQueryable<TType> query,
        PaginationRequestBase? pagination, Expression<Func<TType, object>>? sortablePropertyExpression = null)
    {
        long totalCount = await query.LongCountAsync();

        IOrderedQueryable<TType>? orderedQueryable = null;
        if (pagination is not null)
        {
            query = ProcessPaginate(query, pagination);

            if (sortablePropertyExpression is not null)
            {
                switch (pagination.OrderBy)
                {
                    case OrderBy.Ascending:
                        orderedQueryable = query.OrderBy(sortablePropertyExpression);
                        break;
                    case OrderBy.Descending:
                        orderedQueryable = query.OrderByDescending(sortablePropertyExpression);
                        break;
                }
            }
        }

        var data = orderedQueryable is not null ? await orderedQueryable.ToListAsync() : await query.ToListAsync();

        return new SuccessPaginateDataResponse<ICollection<TType>>(message: string.Empty,
            data: data,
            pagination: new PaginationDto(totalCount: totalCount,
                page: pagination?.Page ?? 1,
                itemCount: pagination?.ItemCount ?? totalCount));
    }

    // protected async Task<IPaginateDataResponse<ICollection<T>>> PaginateAsync(IQueryable<T> query,
    //     PaginationRequestBase? pagination)
    // {
    //     long totalCount = await this.CountAsync(exp: null);
    //
    //     if (pagination is not null)
    //         query = ProcessPaginate(query, pagination);
    //
    //     var data = await query.ToListAsync();
    //
    //     return new SuccessPaginateDataResponse<ICollection<T>>(message: string.Empty,
    //         data: data,
    //         pagination: new PaginationDto(totalCount: totalCount,
    //             page: pagination?.Page ?? 1,
    //             itemCount: pagination?.ItemCount ?? totalCount));
    // }

    protected async Task<IPaginateDataResponse<HashSet<Guid>>> PaginateAsync(IQueryable<Guid> query,
        PaginationRequestBase? pagination)
    {
        long totalCount = await this.CountAsync(exp: null);

        if (pagination is not null)
            query = ProcessPaginate(query, pagination);

        var data = await query.ToListAsync();

        return new SuccessPaginateDataResponse<HashSet<Guid>>(message: string.Empty,
            data: data.ToHashSet(),
            pagination: new PaginationDto(totalCount: totalCount,
                page: pagination?.Page ?? 1,
                itemCount: pagination?.ItemCount ?? totalCount));
    }

    public async Task<IPaginateDataResponse<ICollection<T>>> GetAllPaginateAsync(Expression<Func<T, bool>>? exp = null,
        PaginationRequestBase? pagination = null, RepoFeatures features = default)
    {
        var query = Query(features);

        if (exp is not null)
            query = query.Where(exp);

        return await PaginateAsync(query, pagination);
    }

    public async Task<HashSet<Guid>> GetIdentitiesAsync(Expression<Func<T, bool>>? exp = null,
        RepoFeatures features = default)
    {
        var query = Query(features);

        if (exp is not null)
            query = query.Where(exp);

        var newQuery = query.Select(x => x.Id).AsQueryable();

        var data = await newQuery.ToListAsync();

        return data.ToHashSet();
    }

    public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? exp = null,
        RepoFeatures features = default)
    {
        var query = Query(features);

        if (exp is not null)
            query = query.Where(exp);

        return await query.ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp, RepoFeatures features = default)
    {
        var query = Query(features);

        return await query.AnyAsync(exp);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> exp,
        RepoFeatures features = default)
    {
        var query = Query(features);

        return await query.FirstOrDefaultAsync(exp);
    }

    public async Task<T?> GetByIdAsync(Guid id, RepoFeatures features = default)
    {
        var query = Query(features);

        return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<long> CountAsync(Expression<Func<T, bool>>? exp = null, RepoFeatures features = default)
    {
        var query = Query(features);

        return exp is null ? await query.LongCountAsync() : await query.LongCountAsync(exp);
    }
}