namespace CatQL.Application.Data.Breed;

using Core.Models;
using MediatR;

public class GetBreedRequest : IRequest<Breed>
{
    public GetBreedRequest(int breedId)
        => BreedId = breedId;

    public int BreedId { get; }
}