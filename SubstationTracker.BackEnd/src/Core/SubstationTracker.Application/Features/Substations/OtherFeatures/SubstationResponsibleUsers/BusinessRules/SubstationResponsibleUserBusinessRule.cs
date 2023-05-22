using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetResponsibleUserCountBySubstationId;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUsersByIdentities;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.BusinessRules;

public class SubstationResponsibleUserBusinessRule : IBusinessRules
{
    private readonly ISubstationResponsibleUserReadRepository _readRepository;
    private readonly IMediator _mediator;
    private readonly LanguageService _languageService;

    public SubstationResponsibleUserBusinessRule(
        ISubstationResponsibleUserReadRepository readRepository, IMediator mediator, LanguageService languageService)
    {
        _readRepository = readRepository;
        _mediator = mediator;
        _languageService = languageService;
    }

    public async Task<bool> ResponsibleUsersAreShouldNotResponsibleAnySubstationAsync(
        HashSet<Guid> responsibleUserIdentities)
    {
        var substationResponsibleUsers = await _readRepository.GetAllIncludeSubstationsAsync(
            exp: _substationResponsibleUser =>
                responsibleUserIdentities.Contains(_substationResponsibleUser.ResponsibleUserId));
        if (substationResponsibleUsers.Any() is false)
            return true;

        var usersResult =
            await _mediator.Send(new GetUsersByIdentitiesQueryRequest(identities: responsibleUserIdentities));
        if (usersResult.IsSuccess is false)
            throw new BusinessException(usersResult.Message);

        foreach (var substationResponsibleUser in substationResponsibleUsers)
        {
            foreach (var responsibleUserId in responsibleUserIdentities)
            {
                if (responsibleUserIdentities.Contains(responsibleUserId))
                {
                    var user = usersResult.Data.FirstOrDefault(_user => _user.Id.Equals(responsibleUserId));
                    if (user is null)
                        continue;

                    throw new BusinessException(
                        message: string.Format(
                            _languageService.Get(Messages.TheUserIsAlreadyResposibleFromSubstation),
                            user.FullName,
                            substationResponsibleUser.Substation!.Name));
                }
            }
        }

        return true;
    }

    public async Task<bool> SubstationIsShouldDontHaveAnyResponsibleUserAsync(Guid substationId)
    {
        var responsibleCountOfSubstationResult =
            await _mediator.Send(new GetResponsibleUserCountBySubstationIdQueryRequest(substationId: substationId));
        if (responsibleCountOfSubstationResult.IsSuccess is false)
            throw new ErrorException(responsibleCountOfSubstationResult.Message);

        if (responsibleCountOfSubstationResult.Data is 0)
            return true;

        throw new BusinessException(_languageService.Get(Messages.SubstationIsAlreadyHaveAResponsibleUser));
    }

    public async Task<bool> IsTheUserResponsibleForThisSubstationAsync(Guid userId, Guid substationId)
    {
        bool isResponsibleTheSubstation = await _readRepository.AnyAsync(_substationResponsibleUser =>
            _substationResponsibleUser.SubstationId.Equals(substationId) &&
            _substationResponsibleUser.ResponsibleUserId.Equals(userId));

        return isResponsibleTheSubstation;
    }
    
    public async Task<bool> TheUserIsShouldResponsibleForThisSubstationAsync(Guid userId, Guid substationId)
    {
        var isResponsible = await this.IsTheUserResponsibleForThisSubstationAsync(userId: userId, substationId: substationId);
        if (isResponsible is false)
            throw new BusinessException(_languageService.Get(Messages.TheSubstationIsNotYourResponsibility));

        return true;
    }
}