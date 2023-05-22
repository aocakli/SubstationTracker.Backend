using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Domain.Concrete.Substations._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations._Bases;

public class EfSubstationReadRepository : EfReadRepository<Substation>, ISubstationReadRepository
{
    public EfSubstationReadRepository(DbContext dataContext) : base(dataContext)
    {
    }

    public async Task<IPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>>
        GetSubstationsForListAsync(
            PaginationRequestBase pagination)
    {
        var query = Query(features: new RepoFeatures())
            .Include(_substation => _substation.SubstationSectors)
            .ThenInclude(_substationSector => _substationSector.Sector)
            .Include(_substation => _substation.SubstationResponsibleUsers)
            .ThenInclude(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUser)
            .Select(_substation => new GetSubstationsForListQueryResponse(
                _substation.Id,
                _substation.SubstationResponsibleUsers.Select(_substationResponsibleUser =>
                    string.Join(" ", _substationResponsibleUser.ResponsibleUser!.Name,
                        _substationResponsibleUser.ResponsibleUser.Surname)),
                _substation.SubstationSectors.Select(_substationSector => _substationSector.Sector!.Name),
                _substation.Name,
                _substation.PhoneNumber,
                _substation.Address,
                _substation.Description,
                _substation.PhotoPath,
                _substation.Audit!.CreateAudit!.CreatedDate))
            .AsQueryable();

        return await base.PaginateAsync(query, pagination);
    }

    public async Task<Substation?> GetByIdAsync(Guid id)
    {
        return await Query(features: new RepoFeatures(includeAudit: true))
            .Include(_substation => _substation.SubstationSectors)
            .ThenInclude(_substationSector => _substationSector.Sector)
            .Include(_substation => _substation.SubstationResponsibleUsers)
            .ThenInclude(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUser)
            .FirstOrDefaultAsync(_substation => _substation.Id.Equals(id));
    }
}