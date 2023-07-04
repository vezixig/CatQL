namespace CatQL.Application.Data.Cat;

using Core.Models;
using MediatR;

public class CreateCatRequest : IRequest<Cat>
{
    public CreateCatRequest(Cat cat)
        => Cat = cat;

    public Cat Cat { get; }
}