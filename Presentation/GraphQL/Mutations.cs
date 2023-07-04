namespace CatQL.Presentation.GraphQL;

using Application.Data.Breed;
using Application.Data.Cat;
using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using MediatR;
using Types;

/// <summary>GraphQL mutation to create <see cref="Cat" /></summary>
public class Mutations : ObjectGraphType
{
    private readonly IMediator _mediator;

    public Mutations(IMediator mediator)
    {
        _mediator = mediator;

        Field<CatOutputType>(
            "addCat",
            arguments: new(
                new QueryArgument<NonNullGraphType<CatInputType>> { Name = "cat" }
            ),
            resolve: context =>
            {
                var data = context.GetArgument<Cat>("cat");
                return _mediator.Send(new CreateCatRequest(data)).Result;
            }
        );

        Field<BreedOutputType>(
            "addBreed",
            arguments: new(
                new QueryArgument<NonNullGraphType<BreedInputType>> { Name = "breed" }
            ),
            resolve: context =>
            {
                var data = context.GetArgument<Breed>("breed");
                return _mediator.Send(new CreateBreedRequest(data)).Result;
            }
        );
    }
}