using System.Text.Json.Serialization;

namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.CreateSectorsToProduct;

public class CreateSectorsToProductQueryRequest : IRequest<IResponse>
{
    public CreateSectorsToProductQueryRequest(Guid productId, HashSet<Guid> sectorIdentities, bool isSaveChanges)
    {
        ProductId = productId;
        SectorIdentities = sectorIdentities;
        IsSaveChanges = isSaveChanges;
    }
    public Guid ProductId { get; set; }
    public HashSet<Guid> SectorIdentities { get; set; }
    
    [JsonIgnore] public bool IsSaveChanges { get; set; }
}