namespace CatQL.Application.Requests;

using Core.Models;
using MediatR;

public class GetBreedRequest : IRequest<Breed>
{
    public GetBreedRequest(int breedId)
        => BreedId = breedId;

    public int BreedId { get; }
}