using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.
    GetSubstationsByResponsibleUser;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.
    SubstationResponsibleUsers;

public class EfSubstationResponsibleUserReadRepository : EfReadRepository<SubstationResponsibleUser>,
    ISubstationResponsibleUserReadRepository
{
    public EfSubstationResponsibleUserReadRepository(DbContext dataContext) : base(dataContext)
    {
    }

    public async Task<ICollection<SubstationResponsibleUser>> GetAllIncludeSubstationsAsync(
        Expression<Func<SubstationResponsibleUser, bool>> exp)
    {
        return await base.Query(features: new RepoFeatures())
            .Include(_substationResponsibleUser => _substationResponsibleUser.Substation)
            .Where(exp)
            .ToListAsync();
    }

    public async Task<ICollection<GetSubstationsByResponsibleUserQueryResponse>>
        GetSubstationsByResponsibleUserAsync(Guid userId)
    {
        return await base.Query(features: new RepoFeatures(includeAudit: true))
            .Include(_substationResponsibleUser => _substationResponsibleUser.Substation)
            .Where(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUserId.Equals(userId))
            .Select(_substationResponsibleUser =>
                new GetSubstationsByResponsibleUserQueryResponse(_substationResponsibleUser.Substation!.Id,
                    _substationResponsibleUser.Substation!.Name))
            .ToListAsync();
    }
}