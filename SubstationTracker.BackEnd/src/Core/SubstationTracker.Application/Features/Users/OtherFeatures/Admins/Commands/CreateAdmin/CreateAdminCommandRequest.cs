using SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.Admins.Commands.CreateAdmin;

public class CreateAdminCommandRequest : CreateUserCommandRequest, IRequest<IResponse>
{
}