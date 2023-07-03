namespace CatQL.Application.Requests;

using Core.Models;
using MediatR;

public class CreateBreedRequest : IRequest<Breed>
{
    public CreateBreedRequest(Breed breed)
        => Breed = breed;

    public Breed Breed { get; }
}