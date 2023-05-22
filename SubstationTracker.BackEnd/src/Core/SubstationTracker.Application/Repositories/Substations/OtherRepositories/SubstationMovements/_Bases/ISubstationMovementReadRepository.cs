using System.Linq.Expressions;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;

namespace SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;

public interface ISubstationMovementReadRepository : IReadRepository<SubstationMovement>
{
    Task<ICollection<SubstationMovement>> GetWithIncludesAsync(Expression<Func<SubstationMovement, bool>>? exp = null);
}