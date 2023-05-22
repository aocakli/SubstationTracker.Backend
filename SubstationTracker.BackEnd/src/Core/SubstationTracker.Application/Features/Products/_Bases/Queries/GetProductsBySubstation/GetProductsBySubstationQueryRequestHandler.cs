using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.BusinessRules;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationSectors;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;

public class
    GetProductsBySubstationQueryRequestHandler : IRequestHandler<GetProductsBySubstationQueryRequest,
        IPaginateDataResponse<ICollection<GetProductsBySubstationQueryResponse>>>
{
    private readonly IProductReadRepository _readRepository;
    private readonly SubstationResponsibleUserBusinessRule _substationResponsibleUserBusinessRule;
    private readonly ISubstationSectorReadRepository _substationSectorReadRepository;
    private readonly LanguageService _languageService;
    private readonly IProductSectorReadRepository _productSectorReadRepository;

    public GetProductsBySubstationQueryRequestHandler(IProductReadRepository readRepository,
        SubstationResponsibleUserBusinessRule substationResponsibleUserBusinessRule,
        ISubstationSectorReadRepository substationSectorReadRepository,
        LanguageService languageService,
        IProductSectorReadRepository productSectorReadRepository)
    {
        _readRepository = readRepository;
        _substationResponsibleUserBusinessRule = substationResponsibleUserBusinessRule;
        _substationSectorReadRepository = substationSectorReadRepository;
        _languageService = languageService;
        _productSectorReadRepository = productSectorReadRepository;
    }

    public async Task<IPaginateDataResponse<ICollection<GetProductsBySubstationQueryResponse>>> Handle(
        GetProductsBySubstationQueryRequest request,
        CancellationToken cancellationToken)
    {
        await _substationResponsibleUserBusinessRule.TheUserIsShouldResponsibleForThisSubstationAsync(userId: request.UserId,
            substationId: request.SubstationId);

        var substationSectors = await _substationSectorReadRepository.GetAllAsync(_substationSector =>
            _substationSector.SubstationId.Equals(request.SubstationId));
        if (substationSectors.Any() is false)
            return new ErrorPaginateDataResponse<ICollection<GetProductsBySubstationQueryResponse>>(
                _languageService.Get(Messages.SubstationSectorsAreNotFound));

        var sectorIdentities = substationSectors
            .Select(_substationSector => _substationSector.SectorId)
            .ToHashSet();

        return await _productSectorReadRepository.GetProductsBySectorsAsync(sectorIdentities: sectorIdentities,
            pagination: request.Pagination);
    }
}