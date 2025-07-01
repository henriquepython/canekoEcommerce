using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.ViewModels.Manufacturer;

public class ManufacturerCreateViewModel
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
