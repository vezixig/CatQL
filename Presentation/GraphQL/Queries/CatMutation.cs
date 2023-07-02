namespace CatQL.Presentation.GraphQL.Queries;

using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using Infrastructure;
using MediatR;
using Types;

public class CatMutation : ObjectGraphType
{
    private readonly DataContext _dataContext;

    public CatMutation(IMediator mediator)
        //_dataContext = dataContext;
        => Field<CatOutputType>(
            "addCat",
            arguments: new QueryArguments(
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