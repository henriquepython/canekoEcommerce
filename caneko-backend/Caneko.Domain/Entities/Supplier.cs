using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class Supplier : BaseEntity
{
    public Supplier(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null)
        : base(deleted, createDate, updateDate)
    {
    }
    
    [BsonElement("name")]
    public string Name { get; set; }

}
