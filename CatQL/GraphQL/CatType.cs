namespace API.GraphQL;

using Core.Models;
using global::GraphQL.Types;

public class CatType : ObjectGraphType<Cat>
{
    public CatType()
    {
        Field(x => x.Id).Description("The Id of the cat.");
        Field(x => x.Name).Description("The name of the cat.");
    }
}