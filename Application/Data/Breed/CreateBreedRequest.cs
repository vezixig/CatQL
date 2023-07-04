namespace CatQL.Application.Data.Breed;

using Core.Models;
using MediatR;

public class CreateBreedRequest : IRequest<Breed>
{
    public CreateBreedRequest(Breed breed)
        => Breed = breed;

    public Breed Breed { get; }
}