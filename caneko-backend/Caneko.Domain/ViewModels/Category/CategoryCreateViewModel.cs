using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.ViewModels.Category;

public class CategoryCreateViewModel
{
    [BsonElement("name")]
    public required string Name { get; set; }
}
