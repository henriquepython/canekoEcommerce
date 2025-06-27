using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class ColorItem : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
}
