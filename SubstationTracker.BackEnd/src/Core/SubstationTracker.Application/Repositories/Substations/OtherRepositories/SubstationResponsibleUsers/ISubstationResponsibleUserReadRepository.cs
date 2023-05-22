using System.Linq.Expressions;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.
    GetSubstationsByResponsibleUser;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;

namespace SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;

public interface ISubstationResponsibleUserReadRepository : IReadRepository<SubstationResponsibleUser>
{
    Task<ICollection<SubstationResponsibleUser>> GetAllIncludeSubstationsAsync(
        Expression<Func<SubstationResponsibleUser, bool>> exp);

    Task<ICollection<GetSubstationsByResponsibleUserQueryResponse>> GetSubstationsByResponsibleUserAsync(Guid userId);
}