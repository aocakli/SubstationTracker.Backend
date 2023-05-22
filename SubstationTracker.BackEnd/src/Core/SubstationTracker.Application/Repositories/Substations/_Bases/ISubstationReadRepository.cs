using SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Substations._Bases;

namespace SubstationTracker.Application.Repositories.Substations._Bases;

public interface ISubstationReadRepository : IReadRepository<Substation>
{
    Task<IPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>> GetSubstationsForListAsync(
        PaginationRequestBase pagination);

    Task<Substation?> GetByIdAsync(Guid id);
}