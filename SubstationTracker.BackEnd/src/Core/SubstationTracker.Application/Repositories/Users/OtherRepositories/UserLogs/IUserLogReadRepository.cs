using System.Linq.Expressions;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;

namespace SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;

public interface IUserLogReadRepository : IReadRepository<UserLog>
{
    Task<IPaginateDataResponse<ICollection<GetUserLogListQueryResponse>>> GetUserLogListAsync(
        PaginationRequestBase pagination, Expression<Func<UserLog, bool>>? exp = null);
}