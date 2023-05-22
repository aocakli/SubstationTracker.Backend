using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SubstationTracker.Domain.Abstractions;

public class DocumentBase : IDocument
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    [BsonElement("created-date")] public DateTime CreatedDate { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public void SoftDelete()
    {
        IsDeleted = true;
    }
}