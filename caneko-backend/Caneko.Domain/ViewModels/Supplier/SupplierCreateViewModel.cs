using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.ViewModels.Supplier;

public class SupplierCreateViewModel
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
