using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.ViewModels.Recommend;

public class RecommendCreateViewModel
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
