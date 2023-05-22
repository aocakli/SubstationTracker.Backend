using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

public class EfAuditedWriteRepositoryWithSoftDelete<T> : EfAuditedWriteRepository<T>, IWriteRepositoryWithSoftDelete<T>
    where T : class, IHistoryEntity, ISoftDelete
{
    private readonly RequestService _requestService;

    public EfAuditedWriteRepositoryWithSoftDelete(DbContext dbContext, RequestService requestService) : base(dbContext,
        requestService)
    {
        _requestService = requestService;
    }

    public async Task SoftDeleteAsync(T entity)
    {
        if (entity.Audit is null)
        {
            await DbContext.Entry(entity).Reference(x => x.Audit).LoadAsync();

            entity.Audit ??= new Audit();
        }

        entity.Audit.DeleteAudit = new DeleteAudit()
        {
            DeletedDate = DateTime.UtcNow,
            DeletedById = _requestService.PerpetratorUserId
        };

        entity.IsDeleted = true;

        await base.UpdateAsync(entity);
    }
}