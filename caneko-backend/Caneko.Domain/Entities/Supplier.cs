using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class Supplier : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }

}
