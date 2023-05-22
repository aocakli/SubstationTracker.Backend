using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users._Bases.BusinessRules;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Commands.CreateRolesToUser;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.GenerateUserVerification;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;

public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest, IDataResponse<User>>
{
    private readonly LanguageService _languageService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IUserWriteRepository _writeRepository;

    public CreateUserCommandRequestHandler(IUserWriteRepository writeRepository, IMapper mapper,
        UserBusinessRules userBusinessRules, LanguageService languageService, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _languageService = languageService;
        _mediator = mediator;
    }

    public async Task<IDataResponse<User>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.EmailShouldNotExistInDatabaseAsync(request.Email);

        var userToAdd = _mapper.Map<CreateUserCommandRequest, User>(request);

        userToAdd.Password = HashingHelper.HashPassword(userToAdd.Password);

        await _writeRepository.CreateAsync(userToAdd);

        var createRolesToUserResult = await _mediator.Send(new CreateRolesToUserCommandRequest(userId: userToAdd.Id,
            roles: request.Roles,
            isSaveChanges: false));
        if (createRolesToUserResult.IsSuccess is false)
            return new ErrorDataResponse<User>(createRolesToUserResult.Message);

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.UserIsNotCreated));

        return new SuccessDataResponse<User>(_languageService.Get(Messages.UserIsCreated), userToAdd);
    }
}