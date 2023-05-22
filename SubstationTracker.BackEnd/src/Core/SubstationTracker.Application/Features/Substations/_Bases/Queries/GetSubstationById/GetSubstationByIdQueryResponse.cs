using SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;
using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Domain.Concrete.Substations._Bases.Base;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;

public class GetSubstationByIdQueryResponse : ISubstationBase
{
    public GetSubstationByIdQueryResponse(Guid id,
        ICollection<GetSectorsByIdentitiesQueryResponse> sectors,
        ICollection<UserDto> responsibleUserIdentities,
        string name,
        string phoneNumber,
        string address,
        string description,
        string photoPath)
    {
        Id = id;
        Sectors = sectors;
        ResponsibleUsers = responsibleUserIdentities;
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Description = description;
        PhotoPath = photoPath;
    }

    public Guid Id { get; set; }
    public ICollection<GetSectorsByIdentitiesQueryResponse> Sectors { get; set; }
    public ICollection<UserDto> ResponsibleUsers { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }

    public static GetSubstationByIdQueryResponse Create(Guid id,
        ICollection<GetSectorsByIdentitiesQueryResponse>? sectors,
        ICollection<UserDto>? responsibleUsers,
        string name,
        string phoneNumber,
        string address,
        string description,
        string photoPath)
    {
        return new GetSubstationByIdQueryResponse(id: id,
            sectors: sectors ?? new List<GetSectorsByIdentitiesQueryResponse>(),
            responsibleUserIdentities: responsibleUsers ?? new List<UserDto>(),
            name: name,
            phoneNumber: phoneNumber,
            address: address,
            description: description,
            photoPath: photoPath);
    }
}