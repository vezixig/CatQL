namespace CatQL.Presentation.GraphQL.Mutations;

using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using Infrastructure;
using MediatR;
using Types;

/// <summary>GraphQL mutation to create <see cref="Cat" /></summary>
public class CatMutation : ObjectGraphType<Cat>
{
    private readonly DataContext _dataContext;

    public CatMutation(IMediator mediator)
        //_dataContext = dataContext;
        => Field<CatOutputType>(
            "addCat",
            arguments: new(
                new QueryArgument<NonNullGraphType<CatInputType>> { Name = "cat" }
            ),
            resolve: context =>
            {
                var cat = context.GetArgument<Cat>("cat");
                return AddCat(cat);
            }
        );

    private Cat AddCat(Cat cat)
        //_dataContext.Cats.Add(cat);
        //_dataContext.SaveChanges();
        => cat;
}