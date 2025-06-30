using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.ViewModels.Brand;

public class BrandCreateViewModel
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
