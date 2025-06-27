using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class Brand : BaseEntity
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
