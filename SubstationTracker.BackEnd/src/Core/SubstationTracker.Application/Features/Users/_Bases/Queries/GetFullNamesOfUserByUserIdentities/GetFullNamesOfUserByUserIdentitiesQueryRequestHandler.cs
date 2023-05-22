using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;

public class
    GetFullNamesOfUserByUserIdentitiesQueryRequestHandler : IRequestHandler<
        GetFullNamesOfUserByUserIdentitiesQueryRequest,
        IDataResponse<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>>>
{
    private readonly IUserReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetFullNamesOfUserByUserIdentitiesQueryRequestHandler(IUserReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>>> Handle(
        GetFullNamesOfUserByUserIdentitiesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var fullNameOfUsers = await _readRepository.GetFullNamesByIdentitiesAsync(identities: request.UserIdentities);
        if (fullNameOfUsers.Any() is false)
            return new ErrorDataResponse<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>>(
                message: _languageService.Get(Messages.UsersAreNotFound));

        return new SuccessDataResponse<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>>(
            message: string.Empty,
            data: fullNameOfUsers);
    }
}