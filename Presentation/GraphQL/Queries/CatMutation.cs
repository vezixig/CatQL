namespace CatQL.Presentation.GraphQL.Queries;

using Core.Models;
using global::GraphQL;
using global::GraphQL.Types;
using Infrastructure;

public class CatMutation : ObjectGraphType
{
    private readonly DataContext _dataContext;

    public CatMutation(DataContext dataContext)
    {
        _dataContext = dataContext;

        Field<CatType>(
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
    }

    private Cat AddCat(Cat cat)
    {
        _dataContext.Cats.Add(cat);
        _dataContext.SaveChanges();
        return cat;
    }
}