using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Notifications.Abstracts;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Commands.
    CreateUserResetPassword;

public class
    CreateUserResetPasswordCommandRequestHandler : IRequestHandler<CreateUserResetPasswordCommandRequest, IResponse>
{
    private readonly IUserReadRepository _readRepository;
    private readonly IUserWriteRepository _writeRepository;
    private readonly LanguageService _languageService;
    private readonly RandomService _randomService;
    private readonly INotificationService _notificationService;

    public CreateUserResetPasswordCommandRequestHandler(IUserReadRepository readRepository,
        IUserWriteRepository writeRepository, LanguageService languageService,
        RandomService randomService, INotificationService notificationService)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _languageService = languageService;
        _randomService = randomService;
        _notificationService = notificationService;
    }

    public async Task<IResponse> Handle(CreateUserResetPasswordCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _readRepository.GetAsync(_user => _user.Email.Equals(request.Email));
        if (user is null)
            return new ErrorResponse(_languageService.Get(Messages.UserIsNotFound));

        string generatedResetCode;
        do
        {
            generatedResetCode = _randomService.GenerateCode(50);
        } while (await _readRepository.AnyAsync(_user => _user.ResetPassword.Code.Equals(generatedResetCode)));

        user.ResetPassword = new()
        {
            Code = generatedResetCode,
            ExpiryDate = DateTime.UtcNow.AddHours(2)
        };

        await _writeRepository.UpdateAsync(user);

        if (await _writeRepository.SaveChangesAsync() is false)
            return new ErrorResponse(_languageService.Get(Messages.ResetPasswordOperationCouldNotBeCompleted));

        await _notificationService.SendUserPasswordResetEmailAsync(user.Id);

        return new SuccessResponse(_languageService.Get(Messages.WeAreSendAResetPasswordEmailToYou));
    }
}