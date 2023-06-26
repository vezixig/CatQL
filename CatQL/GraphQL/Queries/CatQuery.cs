namespace API.GraphQL.Queries;

using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;

public class CatQuery : ObjectGraphType
{
    public CatQuery()
    {
        Field<CatType>(
            "cat",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return GetCatById(id);
            }
        );
    }

    private Cat GetCatById(int id)
    {
        // Your data retrieval logic here
        // Replace with your actual implementation
        // Example implementation:
        var cat = new Cat { Id = id, Name = "Whiskers", Age = 3 };
        return cat;
    }
}