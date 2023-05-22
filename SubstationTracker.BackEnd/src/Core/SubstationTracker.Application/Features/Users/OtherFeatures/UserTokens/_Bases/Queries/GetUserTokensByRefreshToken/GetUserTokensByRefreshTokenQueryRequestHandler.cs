using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.AccessTokens.Queries.
    GenerateUserAccessToken;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.RefreshTokens.Commands.
    CreateUserRefreshToken;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserTokens;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Queries.
    GetUserTokensByRefreshToken;

public class
    GetUserTokensByRefreshTokenQueryRequestHandler : IRequestHandler<GetUserTokensByRefreshTokenQueryRequest,
        IDataResponse<GetUserTokensByRefreshTokenQueryResponse>>
{
    private readonly LanguageService _languageService;
    private readonly IMediator _mediator;
    private readonly IUserTokenReadRepository _userTokenReadRepository;

    public GetUserTokensByRefreshTokenQueryRequestHandler(IMediator mediator,
        LanguageService languageService, IUserTokenReadRepository userTokenReadRepository)
    {
        _mediator = mediator;
        _languageService = languageService;
        _userTokenReadRepository = userTokenReadRepository;
    }

    public async Task<IDataResponse<GetUserTokensByRefreshTokenQueryResponse>> Handle(
        GetUserTokensByRefreshTokenQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userToken = await _userTokenReadRepository.GetAsync(_user =>
            _user.Id.Equals(request.UserId) && _user.Token.Equals(request.RefreshToken));
        if (userToken is null)
            return new ErrorDataResponse<GetUserTokensByRefreshTokenQueryResponse>(
                _languageService.Get(Messages.UserIsNotFound));

        if (DateTime.UtcNow > userToken.ExpiryDate)
            return new ErrorDataResponse<GetUserTokensByRefreshTokenQueryResponse>(
                _languageService.Get(Messages.RefreshTokenIsExpired));

        var generatedAccessTokenResult =
            await _mediator.Send(new GenerateUserAccessTokenQueryRequest(userId: request.UserId));
        if (generatedAccessTokenResult.IsSuccess is false)
            return new ErrorDataResponse<GetUserTokensByRefreshTokenQueryResponse>(generatedAccessTokenResult.Message);

        var createdRefreshTokenResult = await _mediator.Send(new CreateUserRefreshTokenCommandRequest(userId: userToken.Id));
        if (createdRefreshTokenResult.IsSuccess is false)
            return new ErrorDataResponse<GetUserTokensByRefreshTokenQueryResponse>(createdRefreshTokenResult.Message);

        GetUserTokensByRefreshTokenQueryResponse responseModel =
            new(generatedAccessTokenResult.Data, createdRefreshTokenResult.Data);

        return new SuccessDataResponse<GetUserTokensByRefreshTokenQueryResponse>(
            _languageService.Get(Messages.TokensAreGenerated),
            responseModel);
    }
}