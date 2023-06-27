namespace CatQL.Presentation.GraphQL;

using Core.Models;
using global::GraphQL.Types;

public class CatType : ObjectGraphType<Cat>
{
    public CatType()
    {
        Field(x => x.Id).Description("The Id of the cat.");
        Field(x => x.Name).Description("The name of the cat.");
        Field(x => x.Age).Description("The age of the cat.");
        Field(x => x.Birthdate).Description("The date of birth of the cat.");
        Field(x => x.Color).Description("The fur color of the cat.");
    }
}