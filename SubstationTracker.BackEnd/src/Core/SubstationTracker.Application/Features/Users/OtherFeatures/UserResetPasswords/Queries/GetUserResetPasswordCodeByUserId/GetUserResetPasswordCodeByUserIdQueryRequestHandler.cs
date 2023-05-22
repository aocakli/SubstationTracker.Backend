using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.
    GetUserResetPasswordCodeByUserId;

public class
    GetUserResetPasswordCodeByUserIdQueryRequestHandler : IRequestHandler<GetUserResetPasswordCodeByUserIdQueryRequest,
        IDataResponse<GetUserResetPasswordCodeByUserIdQueryResponse>>
{
    private readonly IUserReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetUserResetPasswordCodeByUserIdQueryRequestHandler(IUserReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<GetUserResetPasswordCodeByUserIdQueryResponse>> Handle(
        GetUserResetPasswordCodeByUserIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _readRepository.GetAsync(_user => _user.Id.Equals(request.UserId));
        if (user is null)
            return new ErrorDataResponse<GetUserResetPasswordCodeByUserIdQueryResponse>(
                _languageService.Get(Messages.UserIsNotFound));

        if (user.ResetPassword is null)
            return new ErrorDataResponse<GetUserResetPasswordCodeByUserIdQueryResponse>(
                _languageService.Get(Messages.TheUserDontHaveResetPasswordCode));

        var responseModel =
            new GetUserResetPasswordCodeByUserIdQueryResponse(email: user.Email, code: user.ResetPassword.Code,
                user.ResetPassword.ExpiryDate);

        return new SuccessDataResponse<GetUserResetPasswordCodeByUserIdQueryResponse>(
            _languageService.Get(Messages.TheUserResetPasswordCodeIsBrought), responseModel);
    }
}