using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Commands.CreateUserResetPassword;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.
    CheckResetPasswordCodeAndResetPassword;

public class
    CheckResetPasswordCodeAndResetPasswordQueryRequestHandler : IRequestHandler<
        CheckResetPasswordCodeAndResetPasswordQueryRequest, IResponse>
{
    private readonly IMediator _mediator;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly LanguageService _languageService;

    public CheckResetPasswordCodeAndResetPasswordQueryRequestHandler(IMediator mediator,
        IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository,
        LanguageService languageService)
    {
        _mediator = mediator;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(CheckResetPasswordCodeAndResetPasswordQueryRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetAsync(_user =>
            _user.ResetPassword.Code.Equals(request.ResetPasswordCode));
        if (user is null)
            return new ErrorResponse(_languageService.Get(Messages.ResetPasswordCodeIsInvalid));

        if (user.ResetPassword.ExpiryDate < DateTime.UtcNow)
        {
            var createResetPasswordResult = await _mediator.Send(new CreateUserResetPasswordCommandRequest(user.Email));
            if (createResetPasswordResult.IsSuccess is false)
                throw new ErrorException(_languageService.Get(Messages.ResetPasswordOperationCouldNotBeCompleted));

            string message = string.Join(" ", _languageService.Get(Messages.ResetPasswordCodeIsInvalid),
                createResetPasswordResult.Message);

            return new ErrorResponse(message);
        }

        user.Password = HashingHelper.HashPassword(request.Password);

        user.ResetPassword = null;

        await _userWriteRepository.UpdateAsync(user);

        if (await _userWriteRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.ResetPasswordOperationCouldNotBeCompleted));

        return new SuccessResponse(_languageService.Get(Messages.ResetPasswordOperationIsCompleted));
    }
}