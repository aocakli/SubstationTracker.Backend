using Microsoft.AspNetCore.Http;
using SubstationTracker.Domain.Concrete.Substations._Bases.Base;

namespace SubstationTracker.Application.Features.Substations._Bases.Commands.UpdateSubstation;

public class UpdateSubstationCommandRequest : ISubstationBase, IRequest<IResponse>
{
    public Guid Id { get; set; }
    public HashSet<Guid> SectorIdentities { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public IFormFile? Image { get; set; }
}