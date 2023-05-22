using System.Linq.Expressions;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;
using SubstationTracker.Application.Utilities.Extensions;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;

public class GetUserLogListQueryRequestHandler : IRequestHandler<GetUserLogListQueryRequest,
    IPaginateDataResponse<ICollection<GetUserLogListQueryResponse>>>
{
    private readonly IUserLogReadRepository _readRepository;

    public GetUserLogListQueryRequestHandler(IUserLogReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<IPaginateDataResponse<ICollection<GetUserLogListQueryResponse>>> Handle(
        GetUserLogListQueryRequest request,
        CancellationToken cancellationToken)
    {
        Expression<Func<UserLog, bool>>? expression = null;

        if (request.UserId.HasValue)
            expression = _userLog => _userLog.UserId.Equals(request.UserId.Value);

        if (request.Type.HasValue)
        {
            Expression<Func<UserLog, bool>> exp = _userLog => _userLog.Type.Equals(request.Type.Value);

            expression = expression?.AndAlso(exp) ?? exp;
        }

        return await _readRepository.GetUserLogListAsync(pagination: request.Pagination, exp: expression);
    }
}