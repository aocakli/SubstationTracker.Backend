using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.BusinessRules;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.
    CreateSubstationResponsibleUsers;

public class
    CreateSubstationResponsibleUserCommandRequestHandler : IRequestHandler<CreateSubstationResponsibleUserCommandRequest
        , IResponse>
{
    private readonly ISubstationResponsibleUserWriteRepository _writeRepository;
    private readonly SubstationResponsibleUserBusinessRule _businessRule;
    private readonly LanguageService _languageService;

    public CreateSubstationResponsibleUserCommandRequestHandler(
        ISubstationResponsibleUserWriteRepository writeRepository, SubstationResponsibleUserBusinessRule businessRule,
        LanguageService languageService)
    {
        _writeRepository = writeRepository;
        _businessRule = businessRule;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(CreateSubstationResponsibleUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.CheckBusinessRules)
        {
            await _businessRule.SubstationIsShouldDontHaveAnyResponsibleUserAsync(substationId: request.SubstationId);

            await _businessRule.ResponsibleUsersAreShouldNotResponsibleAnySubstationAsync(
                responsibleUserIdentities: new HashSet<Guid>() { request.ResponsibleUserId });
        }

        await _writeRepository.CreateAsync(SubstationResponsibleUser.Create(substationId: request.SubstationId,
            responsibleUserId: request.ResponsibleUserId));

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.ResponsibleUserIsNotAddedToSubstation));

        return new SuccessResponse(_languageService.Get(Messages.ResponsibleUserIsAddedToSubstation),
            statusCode: HttpStatusCode.Created);
    }
}