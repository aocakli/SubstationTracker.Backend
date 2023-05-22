using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

public class EfAuditedWriteRepository<T> : EfWriteRepository<T> where T : class, IHistoryEntity
{
    protected readonly RequestService RequestService;

    public EfAuditedWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext)
    {
        RequestService = requestService;
    }

    private Audit GetAuditInstance()
    {
        return new Audit()
        {
            Id = Guid.NewGuid(),
            Table = TableName
        };
    }

    private CreateAudit GetCreateAuditInstance(Guid auditId)
    {
        return new CreateAudit()
        {
            Id = Guid.NewGuid(),
            AuditId = auditId,
            CreatedDate = DateTime.UtcNow,
            CreatedById = RequestService.PerpetratorUserId
        };
    }

    private async Task<HashSet<Audit>> CreateAuditBulkAsync(int count)
    {
        HashSet<Audit> audits = new();
        HashSet<CreateAudit> createAudits = new();

        for (int i = 0; i < count; i++)
        {
            var audit = GetAuditInstance();

            var createAudit = GetCreateAuditInstance(auditId: audit.Id);

            audits.Add(audit);
            createAudits.Add(createAudit);
        }

        await DbContext.AddRangeAsync(audits);
        await DbContext.AddRangeAsync(createAudits);

        return audits;
    }

    private async Task UpdateProcess(T entity)
    {
        var entry = DbContext.Entry<T>(entity);

        var editedProperties = entry.Properties.Where(x => x.IsModified).ToList();

        if (editedProperties.Any() is false)
            return;

        Dictionary<string, string> originalValues = new();
        Dictionary<string, string> currentValues = new();

        foreach (var property in editedProperties)
        {
            string propertyName = property.Metadata.Name;

            originalValues.Add(propertyName, property.OriginalValue?.ToString() ?? "null");
            currentValues.Add(propertyName, property.CurrentValue?.ToString() ?? "null");
        }

        var updateAudit = new UpdateAudit()
        {
            UpdatedById = RequestService.PerpetratorUserId,
            UpdatedDate = DateTime.UtcNow,
            BeforeColumnData = JsonSerializer.Serialize(originalValues),
            AfterColumnData = JsonSerializer.Serialize(currentValues)
        };

        if (entity.Audit is null)
        {
            await entry.Reference(x => x.Audit).LoadAsync();

            entity.Audit ??= new Audit();
        }

        entity.Audit.UpdateAudits.Add(updateAudit);
    }

    public override async Task<T> CreateAsync(T entity)
    {
        var audit = GetAuditInstance();

        var createAudit = GetCreateAuditInstance(auditId: audit.Id);

        await DbContext.AddAsync(audit);
        await DbContext.AddAsync(createAudit);

        entity.AuditId = audit.Id;
        await base.CreateAsync(entity);

        return entity;
    }

    public override async Task<IEnumerable<T>> CreateBulkAsync(IEnumerable<T> entities)
    {
        var bulkEntities = entities.ToList();
        var createdAudits = await CreateAuditBulkAsync(bulkEntities.Count);

        for (int i = 0; i < bulkEntities.Count; i++)
        {
            var entity = bulkEntities[i];

            var audit = createdAudits.ToList()[i];

            entity.AuditId = audit.Id;
        }

        await Table.AddRangeAsync(bulkEntities);
        return bulkEntities;
    }

    public override async Task UpdateAsync(T entity)
    {
        await UpdateProcess(entity);

        await Task.FromResult(Table.Update(entity));
    }
}