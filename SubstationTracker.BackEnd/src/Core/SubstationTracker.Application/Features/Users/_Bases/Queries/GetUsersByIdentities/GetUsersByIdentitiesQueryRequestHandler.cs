using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUsers;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUsersByIdentities;

public class
    GetUsersByIdentitiesQueryRequestHandler : IRequestHandler<GetUsersByIdentitiesQueryRequest,
        IDataResponse<ICollection<UserDto>>>
{
    private readonly LanguageService _languageService;
    private readonly IMapper _mapper;
    private readonly IUserReadRepository _readRepository;
    private readonly IMediator _mediator;

    public GetUsersByIdentitiesQueryRequestHandler(IUserReadRepository readRepository, IMapper mapper,
        LanguageService languageService, IMediator mediator)
    {
        _readRepository = readRepository;
        _mapper = mapper;
        _languageService = languageService;
        _mediator = mediator;
    }

    public async Task<IDataResponse<ICollection<UserDto>>> Handle(GetUsersByIdentitiesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _readRepository.GetAllAsync(_user => request.Identities.Contains(_user.Id));
        if (users.Any() is false)
            return new ErrorDataResponse<ICollection<UserDto>>(_languageService.Get(Messages.UsersAreNotFound));

        HashSet<Guid> userIdentities = users.Select(_user => _user.Id).ToHashSet();

        var userRolesResult = await _mediator.Send(new GetRolesByUsersQueryRequest(userIdentities: userIdentities));
        if (userRolesResult.IsSuccess is false)
            return new ErrorDataResponse<ICollection<UserDto>>(message: userRolesResult.Message);

        List<UserDto> userDtos = new();

        foreach (var user in users)
        {
            var userDto = _mapper.Map<User, UserDto>(user);

            userDto.Role = userRolesResult.Data.First(_userRole => _userRole.UserId.Equals(user.Id));

            userDtos.Add(userDto);
        }

        return new SuccessDataResponse<ICollection<UserDto>>(_languageService.Get(Messages.UsersAreListed), userDtos);
    }
}