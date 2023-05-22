using System.Text;
using SubstationTracker.Domain.Concrete.Users._Bases;
using Microsoft.Extensions.Configuration;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserTokens;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.RefreshTokens.Commands.
    CreateUserRefreshToken;

public class
    CreateUserRefreshTokenCommandRequestHandler : IRequestHandler<CreateUserRefreshTokenCommandRequest,
        IDataResponse<CreateUserRefreshTokenCommandResponse>>
{
    private readonly IConfiguration _configuration;
    private readonly LanguageService _languageService;
    private readonly Random _random;
    private readonly IUserTokenReadRepository _userTokenReadRepository;
    private readonly IUserTokenWriteRepository _userTokenWriteRepository;

    public CreateUserRefreshTokenCommandRequestHandler(Random random, IConfiguration configuration,
        LanguageService languageService, IUserTokenWriteRepository userTokenWriteRepository,
        IUserTokenReadRepository userTokenReadRepository)
    {
        _random = random;
        _configuration = configuration;
        _languageService = languageService;
        _userTokenWriteRepository = userTokenWriteRepository;
        _userTokenReadRepository = userTokenReadRepository;
    }

    public async Task<IDataResponse<CreateUserRefreshTokenCommandResponse>> Handle(
        CreateUserRefreshTokenCommandRequest request,
        CancellationToken cancellationToken)
    {
        int refreshTokenLength = Convert.ToInt16(_configuration["Token:RefreshTokenCharLength"]);

        StringBuilder sb = new();

        for (var i = 0; i < refreshTokenLength; i++)
        {
            int generatedValue;

            // Generate number
            if (GetRandomBoolean())
                generatedValue = GetNumber();
            else // Generate char
                generatedValue = GetRandomBoolean() ? GetUpperCase() : GetLowerCase();

            sb.Append((char)generatedValue);
        }

        var expiryDate =
            DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Token:RefreshTokenExpiryAsMinute"]));

        var userExistingTokens =
            await _userTokenReadRepository.GetAllAsync(_userToken => _userToken.UserId.Equals(request.UserId));
        foreach (var userExistingToken in userExistingTokens)
            await _userTokenWriteRepository.HardDeleteAsync(userExistingToken);

        await _userTokenWriteRepository.CreateAsync(new UserToken(userId: request.UserId, token: sb.ToString(),
            expiryDate: expiryDate));

        if (await _userTokenWriteRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.RefreshTokenIsNotGenerated));

        CreateUserRefreshTokenCommandResponse responseModel = new(sb.ToString(), expiryDate);

        return new SuccessDataResponse<CreateUserRefreshTokenCommandResponse>(
            message: _languageService.Get(Messages.RefreshTokenIsGenerated),
            data: responseModel);
    }

    private bool GetRandomBoolean()
    {
        return _random.Next(0, 2) is 0;
    }

    private int GetNumber()
    {
        return _random.Next(48, 57);
    }

    private int GetLowerCase()
    {
        return _random.Next(97, 122);
    }

    private int GetUpperCase()
    {
        return _random.Next(65, 90);
    }
}