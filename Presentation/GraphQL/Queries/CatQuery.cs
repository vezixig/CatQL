namespace CatQL.Presentation.GraphQL.Queries;

using Application.Requests;
using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using MediatR;
using Types;

public class CatQuery : ObjectGraphType<Cat>
{
    private readonly IMediator _mediator;

    public CatQuery(IMediator mediator)
    {
        _mediator = mediator;

        Field<CatOutputType>(
            "cat",
            arguments: new(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                try
                {
                    var id = context.GetArgument<int>("id");
                    return GetCatById(id);
                }
                catch (Exception e)
                {
                    context.Errors.Add(new(e.Message));
                    return null;
                }
            }
        );
    }

    private Cat GetCatById(int id)
    {
        var data = _mediator.Send(new GetCatRequest(id));
        return data.Result;
    }
}