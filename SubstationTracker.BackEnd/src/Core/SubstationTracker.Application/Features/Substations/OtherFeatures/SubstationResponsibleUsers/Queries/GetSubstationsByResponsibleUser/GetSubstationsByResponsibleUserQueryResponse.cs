namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.
    GetSubstationsByResponsibleUser;

public class GetSubstationsByResponsibleUserQueryResponse
{
    public GetSubstationsByResponsibleUserQueryResponse(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
}