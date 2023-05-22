using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUserList;

public class GetUserListQueryResponse
{
    public GetUserListQueryResponse()
    {
    }

    public GetUserListQueryResponse(Guid id, UserRoleTypes role, string email, string name, string surname, DateTime createdDate)
    {
        Id = id;
        Role = role;
        Email = email;
        Name = name;
        Surname = surname;
        CreatedDate = createdDate;
    }

    public Guid Id { get; set; }
    public UserRoleTypes Role { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName => string.Join(" ", Name, Surname);
    public DateTime CreatedDate { get; set; }
}