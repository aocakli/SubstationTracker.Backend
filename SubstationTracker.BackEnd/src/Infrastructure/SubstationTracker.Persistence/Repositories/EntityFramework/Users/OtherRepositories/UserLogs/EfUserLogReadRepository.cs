using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserLogs;

public class EfUserLogReadRepository : EfReadRepository<UserLog>, IUserLogReadRepository
{
    public EfUserLogReadRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IPaginateDataResponse<ICollection<GetUserLogListQueryResponse>>> GetUserLogListAsync(
        PaginationRequestBase pagination, Expression<Func<UserLog, bool>>? exp = null)
    {
        exp ??= x => true;

        var query = Query(features: new RepoFeatures(includeAudit: true, ignoreQueryFilters: true, noTracking: true))
            .Include(_userLog => _userLog.User)
            .Where(exp)
            .OrderByDescending(_userLog => _userLog!.Audit!.CreateAudit!.CreatedDate)
            .Select(_userLog => new GetUserLogListQueryResponse(_userLog.Id,
                _userLog.UserId,
                string.Join(" ", _userLog.User.Name, _userLog.User.Surname),
                _userLog.Type,
                _userLog.Parameters,
                _userLog.IsSuccess,
                _userLog.Audit!.CreateAudit!.CreatedDate));

        return await base.PaginateAsync(query, pagination);
    }
}