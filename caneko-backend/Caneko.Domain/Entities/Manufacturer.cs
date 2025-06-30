using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class Manufacturer : BaseEntity
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
