using System.Linq.Expressions;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.Extensions;
using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUserList;

public class GetUserListQueryRequestHandler : IRequestHandler<GetUserListQueryRequest,
    IPaginateDataResponse<ICollection<GetUserListQueryResponse>>>
{
    private readonly IUserReadRepository _readRepository;

    public GetUserListQueryRequestHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<IPaginateDataResponse<ICollection<GetUserListQueryResponse>>> Handle(
        GetUserListQueryRequest request,
        CancellationToken cancellationToken)
    {
        Expression<Func<User, bool>> exp = x => true;

        if (string.IsNullOrEmpty(request.Contains) is false)
        {
            string loweredContains = request.Contains.ToLower();

            exp = _user => _user.Email.ToLower().Contains(loweredContains) ||
                           _user.Name.ToLower().Contains(loweredContains) ||
                           _user.Surname.ToLower().Contains(loweredContains);
        }

        if (request.Role.HasValue)
        {
            Expression<Func<User, bool>> roleExp = _user =>
                _user.UserRoles.Any(_userRole => _userRole.Role.Equals(request.Role.Value));

            exp = exp.AndAlso(roleExp);
        }

        return await _readRepository.GetUserListAsync(pagination: request.Pagination, exp: exp);
    }
}