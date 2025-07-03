using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class ColorItem : BaseEntity
{
    public ColorItem(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null)
        : base(deleted, createDate, updateDate)
    {
    }

    [BsonElement("name")]
    public required string Name { get; set; }
}
