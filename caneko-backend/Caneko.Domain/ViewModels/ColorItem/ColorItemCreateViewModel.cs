using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.ViewModels.ColorItem;

public class ColorItemCreateViewModel
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
