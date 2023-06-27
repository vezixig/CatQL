namespace CatQL.Presentation.GraphQL.Queries;

using Application.Requests;
using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using MediatR;

public class CatQuery : ObjectGraphType
{
    private readonly IMediator _mediator;

    public CatQuery(IMediator mediator)
    {
        _mediator = mediator;

        Field<CatType>(
            "cat",
            arguments: new(
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
        var data = _mediator.Send(new GetCatRequest(id));
        return data.Result;
    }
}