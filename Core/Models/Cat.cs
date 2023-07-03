namespace CatQL.Core.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SourceCodeGenerator.Attributes;
using SourceCodeGenerator.Enums;

[GenerateSchema(SchemaOptions.Mutation | SchemaOptions.Query)]
public class Cat
{
    [Output]
    public int Id { get; set; }

    [Input]
    [Output]
    [Required]
    [MaxLength(250)]
    [Description("The name of the cat")]
    public string Name { get; set; } = string.Empty;

    [Input]
    [Output]
    [Required]
    [Description("The age of the cat in full years")]
    public int Age { get; set; }

    [Input]
    [Output]
    [Required]
    public string Color { get; set; } = string.Empty;

    [Input]
    public int Weight { get; set; }

    [Output]
    [Input]
    public DateTime Birthdate { get; set; }

    [Output]
    public Breed Breed { get; set; }
}