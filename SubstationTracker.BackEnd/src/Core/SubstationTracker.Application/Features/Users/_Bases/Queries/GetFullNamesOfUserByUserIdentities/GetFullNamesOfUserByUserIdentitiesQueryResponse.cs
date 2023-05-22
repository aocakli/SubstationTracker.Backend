namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;

public class GetFullNamesOfUserByUserIdentitiesQueryResponse
{
    public GetFullNamesOfUserByUserIdentitiesQueryResponse(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName => string.Join(" ", Name, Surname);

    public static GetFullNamesOfUserByUserIdentitiesQueryResponse Create(Guid id, string name, string surname)
    {
        return new GetFullNamesOfUserByUserIdentitiesQueryResponse(id: id, name: name, surname: surname);
    }
}