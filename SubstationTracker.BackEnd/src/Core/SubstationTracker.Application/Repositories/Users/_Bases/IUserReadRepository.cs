using System.Linq.Expressions;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUserList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Application.Repositories.Users._Bases;

public interface IUserReadRepository : IReadRepository<User>
{
    Task<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>> GetFullNamesByIdentitiesAsync(
        HashSet<Guid> identities);

    Task<IPaginateDataResponse<ICollection<GetUserListQueryResponse>>>
        GetUserListAsync(PaginationRequestBase pagination,
            Expression<Func<User, bool>> exp);
}