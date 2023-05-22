using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.Admins.Queries.GetAdminEmailAddresses;

public class
    GetAdminEmailAddressesQueryRequestHandler : IRequestHandler<GetAdminEmailAddressesQueryRequest,
        IDataResponse<HashSet<string>>>
{
    private readonly LanguageService _languageService;
    private readonly IUserReadRepository _userRepository;

    public GetAdminEmailAddressesQueryRequestHandler(IUserReadRepository userRepository,
        LanguageService languageService)
    {
        _userRepository = userRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<HashSet<string>>> Handle(GetAdminEmailAddressesQueryRequest request,
        CancellationToken cancellationToken)
    {
        // var adminEmails = await _userRepository.GetEmailsByRoleAsync(UserRoles.Admin);
        // if (adminEmails.Any() is false)
        //     return new ErrorDataResponse<HashSet<string>>(_languageService.Get(Messages.EmailsAreNotFound));
        //
        // return new SuccessDataResponse<HashSet<string>>(_languageService.Get(Messages.EmailsAreListed), adminEmails);

        return null;
    }
}