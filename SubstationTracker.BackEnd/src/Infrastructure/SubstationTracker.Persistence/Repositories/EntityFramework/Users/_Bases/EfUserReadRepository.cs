using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUserList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users._Bases;

public class EfUserReadRepository : EfReadRepository<User>, IUserReadRepository
{
    public EfUserReadRepository(DbContext dataContext) : base(dataContext)
    {
    }


    public async Task<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>> GetFullNamesByIdentitiesAsync(
        HashSet<Guid> identities)
    {
        return await Query(features: default)
            .Where(_user => identities.Contains(_user.Id))
            .Select(_user => new GetFullNamesOfUserByUserIdentitiesQueryResponse(_user.Id, _user.Name, _user.Surname))
            .ToListAsync();
    }

    public async Task<IPaginateDataResponse<ICollection<GetUserListQueryResponse>>> GetUserListAsync(
        PaginationRequestBase pagination, Expression<Func<User, bool>> exp)
    {
        var query = Query(features: new RepoFeatures(includeAudit: true))
            .Include(_user => _user.UserRoles)
            .AsNoTracking()
            .Where(exp)
            .Select(_user => new GetUserListQueryResponse(_user.Id,
                _user.UserRoles.First().Role,
                _user.Email,
                _user.Name,
                _user.Surname,
                _user.Audit!.CreateAudit!.CreatedDate)
            );

        return await base.PaginateAsync(query: query, pagination: pagination);
    }
}