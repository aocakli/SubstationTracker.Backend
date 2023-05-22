using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUserById;

public class GetUserByIdQueryRequest : IRequest<IDataResponse<UserDto>>
{
    public GetUserByIdQueryRequest()
    {
    }

    public GetUserByIdQueryRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}