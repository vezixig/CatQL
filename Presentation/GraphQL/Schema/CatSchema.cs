namespace CatQL.Presentation.GraphQL.Schema;

using global::GraphQL.Types;
using Infrastructure;
using MediatR;
using Queries;

public class CatSchema : Schema
{
    public CatSchema(DataContext dataContext, IMediator mediator)
    {
        Query = new CatQuery(mediator);
        Mutation = new CatMutation(dataContext);
    }
}