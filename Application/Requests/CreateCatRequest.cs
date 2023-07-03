namespace CatQL.Application.Requests;

using Core.Models;
using MediatR;

public class CreateCatRequest : IRequest<Cat>
{
    public CreateCatRequest(Cat cat)
        => Cat = cat;

    public Cat Cat { get; }
}