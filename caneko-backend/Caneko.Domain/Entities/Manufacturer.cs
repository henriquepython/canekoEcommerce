using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class Manufacturer : BaseEntity
{
    public Manufacturer(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null)
        : base(deleted, createDate, updateDate)
    {
    }
    
    [BsonElement("name")]
    public required string Name { get; set; }
}
