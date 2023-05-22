using SubstationTracker.Domain.Concrete.Substations._Bases.Base;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;

public class GetSubstationsForListQueryResponse : ISubstationBase
{
    public GetSubstationsForListQueryResponse()
    {
    }

    public GetSubstationsForListQueryResponse(Guid id, IEnumerable<string> responsibleUserFullNames,
        IEnumerable<string> sectors, string name, string phoneNumber, string address, string description,
        string photoPath,
        DateTime createdDate)
    {
        Id = id;
        ResponsibleUserFullNames = responsibleUserFullNames;
        Sectors = sectors;
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Description = description;
        PhotoPath = photoPath;
        CreatedDate = createdDate;
    }

    public Guid Id { get; set; }
    public IEnumerable<string> ResponsibleUserFullNames { get; set; }
    public IEnumerable<string> Sectors { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }
    public DateTime CreatedDate { get; set; }

    public static GetSubstationsForListQueryResponse Create(Guid id,
        IEnumerable<string> responsibleUserFullNames,
        IEnumerable<string> sectors,
        string name,
        string phoneNumber,
        string address,
        string description,
        string photoPath,
        DateTime createdDate)
    {
        return new GetSubstationsForListQueryResponse(id: id,
            responsibleUserFullNames: responsibleUserFullNames.ToHashSet(),
            sectors: sectors.ToHashSet(),
            name: name,
            phoneNumber: phoneNumber,
            address: address,
            description: description,
            photoPath: photoPath,
            createdDate: createdDate);
    }
}