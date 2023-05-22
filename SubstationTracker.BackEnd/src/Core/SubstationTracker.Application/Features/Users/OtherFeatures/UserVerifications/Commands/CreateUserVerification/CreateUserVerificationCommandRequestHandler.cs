using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Notifications.Abstracts;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.GenerateUserVerification;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.CreateUserVerification;

public class
    CreateUserVerificationCommandRequestHandler : IRequestHandler<CreateUserVerificationCommandRequest, IResponse>
{
    private readonly LanguageService _languageService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly INotificationService _notificationService;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public CreateUserVerificationCommandRequestHandler(IMediator mediator, IMapper mapper,
        IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository,
        LanguageService languageService, INotificationService notificationService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _languageService = languageService;
        _notificationService = notificationService;
    }

    public async Task<IResponse> Handle(CreateUserVerificationCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetAsync(_user => request.UserId.Equals(_user.Id));
        if (user is null)
            return new ErrorResponse(_languageService.Get(Messages.UserIsNotFound));

        var generatedUserVerificationResult =
            await _mediator.Send(new GenerateUserVerificationCommandRequest(request.VerificationType));
        if (generatedUserVerificationResult.IsSuccess is false)
            return new ErrorResponse(generatedUserVerificationResult.Message);

        // Remove old codes.
        user.UserVerifications = user.UserVerifications?
            .Where(_userVerification => _userVerification.VerificationType.Equals(request.VerificationType) == false)?
            .ToList();

        (user.UserVerifications ??= new List<UserVerification>()).Add(generatedUserVerificationResult.Data);

        await _userWriteRepository.UpdateAsync(user);

        await _userWriteRepository.SaveChangesAsync();

        return new SuccessResponse(_languageService.Get(Messages.UserVerificationIsAdded));
    }
}