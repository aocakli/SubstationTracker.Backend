using System.Text;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Services;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.GenerateUserVerification;

public class
    GenerateUserVerificationCommandRequestHandler : IRequestHandler<GenerateUserVerificationCommandRequest,
        IDataResponse<UserVerification>>
{
    private const byte VerificationCodeLength = 100;
    private const byte VerificationCodeExpiryDateAsHour = 2;
    private readonly LanguageService _languageService;

    private readonly IMapper _mapper;
    private readonly RandomService _randomService;

    public GenerateUserVerificationCommandRequestHandler(IMapper mapper, LanguageService languageService,
        RandomService randomService)
    {
        _mapper = mapper;
        _languageService = languageService;
        _randomService = randomService;
    }

    public async Task<IDataResponse<UserVerification>> Handle(GenerateUserVerificationCommandRequest request,
        CancellationToken cancellationToken)
    {
        var userVerification = _mapper.Map<GenerateUserVerificationCommandRequest, UserVerification>(request);

        userVerification.Code = _randomService.GenerateCode(VerificationCodeLength);

        userVerification.ExpiryDate = DateTime.UtcNow.AddHours(VerificationCodeExpiryDateAsHour);

        return new SuccessDataResponse<UserVerification>(_languageService.Get(Messages.UserVerificationIsGenerated),
            userVerification);
    }
}