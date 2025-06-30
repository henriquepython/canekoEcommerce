using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class UnitOfMeasurement : BaseEntity
{

    [BsonElement("name")]
    public required string Name { get; set; }

    [BsonElement("acronym")]
    public string? Acronym { get; set; }
}
