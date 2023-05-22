namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.
    GetSubstationsByResponsibleUser;

public class
    GetSubstationsByResponsibleUserQueryRequest : IRequest<
        IDataResponse<ICollection<GetSubstationsByResponsibleUserQueryResponse>>>
{
    public GetSubstationsByResponsibleUserQueryRequest()
    {
    }

    public GetSubstationsByResponsibleUserQueryRequest(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}