using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUsersByIdentities;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUserById;

public class GetUserByIdQueryRequestHandler : IRequestHandler<GetUserByIdQueryRequest, IDataResponse<UserDto>>
{
    private readonly LanguageService _languageService;
    private readonly IMediator _mediator;


    public GetUserByIdQueryRequestHandler(IMediator mediator, LanguageService languageService)
    {
        _mediator = mediator;
        _languageService = languageService;
    }

    public async Task<IDataResponse<UserDto>> Handle(GetUserByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userResult = await _mediator.Send(new GetUsersByIdentitiesQueryRequest(request.Id));
        if (userResult.IsSuccess is false)
            return new ErrorDataResponse<UserDto>(userResult.Message);

        if (userResult.Data.FirstOrDefault() is null)
            return new ErrorDataResponse<UserDto>(userResult.Message);

        return new SuccessDataResponse<UserDto>(_languageService.Get(Messages.UserIsBrought), userResult.Data.First());
    }
}