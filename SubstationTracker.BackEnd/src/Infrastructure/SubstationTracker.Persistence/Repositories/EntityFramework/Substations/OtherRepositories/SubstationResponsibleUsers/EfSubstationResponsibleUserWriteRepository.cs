using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.
    SubstationResponsibleUsers;

public class EfSubstationResponsibleUserWriteRepository :
    EfAuditedWriteRepositoryWithSoftDelete<SubstationResponsibleUser>,
    ISubstationResponsibleUserWriteRepository
{
    public EfSubstationResponsibleUserWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}