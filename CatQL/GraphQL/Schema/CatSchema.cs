namespace API.GraphQL.Schema;

using global::GraphQL.Types;
using Infrastructure;
using Queries;

public class CatSchema : Schema
{
    public CatSchema(DataContext dataContext)
    {
        Query = new CatQuery();
        Mutation = new CatMutation(dataContext); // If you have mutation operations
    }
}