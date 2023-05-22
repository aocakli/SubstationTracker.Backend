using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;
using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUserById;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.AccessTokens.Queries.
    GenerateUserAccessToken;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.RefreshTokens.Commands.
    CreateUserRefreshToken;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.LoginUser;

public class
    LoginUserQueryRequestHandler : IRequestHandler<LoginUserQueryRequest, IDataResponse<LoginUserQueryResponse>>
{
    private readonly LanguageService _languageService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IUserReadRepository _readRepository;

    public LoginUserQueryRequestHandler(IUserReadRepository readRepository, IMapper mapper, IMediator mediator,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _mapper = mapper;
        _mediator = mediator;
        _languageService = languageService;
    }

    public async Task<IDataResponse<LoginUserQueryResponse>> Handle(LoginUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        start:
        var user = await _readRepository.GetAsync(_user => request.Email.Equals(_user.Email));
        if (user is null)
        {
            if (await _readRepository.CountAsync() is 0)
            {
                var createUserResult = await _mediator.Send(new CreateUserCommandRequest(
                    name: "Super",
                    surname: "Admin",
                    email: request.Email,
                    password: request.Password,
                    confirmPassword: request.Password,
                    roles: new HashSet<UserRoleTypes>() { UserRoleTypes.Admin },
                    isSaveChanges: true));
                if (createUserResult.IsSuccess is false)
                    return new ErrorDataResponse<LoginUserQueryResponse>(createUserResult.Message);

                goto start;
            }
            else
            {
                return new ErrorDataResponse<LoginUserQueryResponse>(
                    _languageService.Get(Messages.EmailOrPasswordIncorrect));
            }
        }

        if (HashingHelper.VerifyPassword(request.Password, hash: user.Password) is false)
            return new ErrorDataResponse<LoginUserQueryResponse>(
                _languageService.Get(Messages.EmailOrPasswordIncorrect));

        var userResult = await _mediator.Send(new GetUserByIdQueryRequest(id: user.Id));
        if (userResult.IsSuccess is false)
            return new ErrorDataResponse<LoginUserQueryResponse>(userResult.Message);

        var loginDto = _mapper.Map<UserDto, LoginUserQueryResponse>(userResult.Data);

        await GenerateUserAccessTokenAndMapAsync(userId: user.Id, loginDto);

        await CreateUserRefreshTokenAndMapAsync(userId: user.Id, loginDto);

        return new SuccessDataResponse<LoginUserQueryResponse>(_languageService.Get(Messages.LoginOperationIsSuccess),
            loginDto);
    }

    private async Task GenerateUserAccessTokenAndMapAsync(Guid userId, LoginUserQueryResponse loginDto)
    {
        var generatedUserAccessTokenResult = await _mediator.Send(new GenerateUserAccessTokenQueryRequest(userId));
        if (generatedUserAccessTokenResult.IsSuccess is false)
            throw new ErrorException(generatedUserAccessTokenResult.Message);

        loginDto.AccessToken = generatedUserAccessTokenResult.Data;
    }

    private async Task CreateUserRefreshTokenAndMapAsync(Guid userId, LoginUserQueryResponse loginDto)
    {
        var createdUserRefreshTokenResult =
            await _mediator.Send(new CreateUserRefreshTokenCommandRequest(userId: userId));
        if (createdUserRefreshTokenResult.IsSuccess is false)
            throw new ErrorException(createdUserRefreshTokenResult.Message);

        loginDto.RefreshToken = createdUserRefreshTokenResult.Data;
    }
}