namespace CatQL.Presentation.GraphQL;

using Application.Requests;
using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using MediatR;
using Types;

public class Queries : ObjectGraphType<Cat>
{
    private readonly IMediator _mediator;

    public Queries(IMediator mediator)
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
                    return _mediator.Send(new GetCatRequest(id)).Result;
                }
                catch (Exception e)
                {
                    context.Errors.Add(new(e.Message));
                    return null;
                }
            }
        );

        Field<BreedOutputType>(
            "breed",
            arguments: new(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                try
                {
                    var id = context.GetArgument<int>("id");
                    return _mediator.Send(new GetBreedRequest(id)).Result;
                }
                catch (Exception e)
                {
                    context.Errors.Add(new(e.Message));
                    return null;
                }
            }
        );
    }
}