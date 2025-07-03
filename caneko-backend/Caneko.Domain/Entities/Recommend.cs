using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

public class Recommend : BaseEntity
{
    public Recommend(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null)
        : base(deleted, createDate, updateDate)
    {
    }

    [BsonElement("name")]
    public string Name { get; set; }

}
