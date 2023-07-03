namespace CatQL.Core.Models;

using SourceCodeGenerator.Attributes;
using SourceCodeGenerator.Enums;

[GenerateSchema(SchemaOptions.Query | SchemaOptions.Mutation)]
public class Breed
{
    [Output]
    public int Id { get; set; }

    [Input]
    [Output]
    public string Name { get; set; }

    [Input]
    [Output]
    public string Origin { get; set; }

    [Input]
    [Output]
    public string Description { get; set; }
}