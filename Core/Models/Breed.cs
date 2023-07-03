namespace CatQL.Core.Models;

using SourceCodeGenerator.Attributes;
using SourceCodeGenerator.Enums;

[GenerateSchema(SchemaOptions.Query)]
public class Breed
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Origin { get; set; }

    public string Description { get; set; }
}