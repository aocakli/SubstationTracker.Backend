using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.BusinessRules;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.
    CreateSubstationResponsibleUsers;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUsersByIdentities;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.
    AssignResponsiblesToSubstation;

public class
    AssignResponsiblesToSubstationCommandRequestHandler : IRequestHandler<AssignResponsiblesToSubstationCommandRequest,
        IResponse>
{
    private readonly IMediator _mediator;
    private readonly LanguageService _languageService;
    private readonly ISubstationResponsibleUserReadRepository _readRepository;
    private readonly ISubstationResponsibleUserWriteRepository _writeRepository;
    private readonly SubstationResponsibleUserBusinessRule _businessRule;

    public AssignResponsiblesToSubstationCommandRequestHandler(IMediator mediator, LanguageService languageService,
        ISubstationResponsibleUserReadRepository readRepository,
        ISubstationResponsibleUserWriteRepository writeRepository, SubstationResponsibleUserBusinessRule businessRule)
    {
        _mediator = mediator;
        _languageService = languageService;
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _businessRule = businessRule;
    }

    public async Task<IResponse> Handle(AssignResponsiblesToSubstationCommandRequest request,
        CancellationToken cancellationToken)
    {
        var userResult =
            await _mediator.Send(new GetUsersByIdentitiesQueryRequest(identities: request.UserIdentities));
        if (userResult.IsSuccess is false)
            return new ErrorResponse(userResult.Message);

        if (request.CanTransferTheResponsibleUser)
        {
            var previousSubsationsResponsibleUsers = await _readRepository.GetAllAsync(
                exp: _substationResponsibleUser =>
                    request.UserIdentities.Contains(_substationResponsibleUser.ResponsibleUserId),
                features: new RepoFeatures(includeAudit: true, noTracking: false));

            foreach (var previousSubsationsResponsibleUser in previousSubsationsResponsibleUsers)
                await _writeRepository.SoftDeleteAsync(previousSubsationsResponsibleUser);
        }
        else
        {
            await _businessRule.ResponsibleUsersAreShouldNotResponsibleAnySubstationAsync(
                responsibleUserIdentities: request.UserIdentities);

            await _businessRule.SubstationIsShouldDontHaveAnyResponsibleUserAsync(substationId: request.SubstationId);
        }

        var createSubstationResponsibleUserResult = await _mediator.Send(
            new CreateSubstationResponsibleUserCommandRequest(
                substationId: request.SubstationId,
                responsibleUserId: request.UserIdentities.First(),
                checkBusinessRules: false,
                isSaveChanges: false));
        if (createSubstationResponsibleUserResult.IsSuccess is false)
            return new ErrorResponse(createSubstationResponsibleUserResult.Message);

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.UserIsNotAssignedToSubstation));

        return new SuccessResponse(_languageService.Get(Messages.UserIsAssignedToSubstation));
    }
}