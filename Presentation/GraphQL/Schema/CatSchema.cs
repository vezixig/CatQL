namespace CatQL.Presentation.GraphQL.Schema;

using Core.Models;
using global::GraphQL.Types;
using Infrastructure;
using MediatR;
using Queries;

/// <summary>GraphQL Schema for <see cref="Cat" /></summary>
public class CatSchema : Schema
{
    public CatSchema(DataContext dataContext, IMediator mediator)
    {
        Query = new CatQuery(mediator);
        Mutation = new CatMutation(dataContext);
    }
}