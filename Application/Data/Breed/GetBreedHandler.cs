namespace CatQL.Application.Data.Breed;

using Core.Models;
using Infrastructure.Repositories.Interfaces;
using MediatR;

internal class GetBreedHandler : IRequestHandler<GetBreedRequest, Breed>
{
    private readonly IBreedRepository _breedRepository;

    public GetBreedHandler(IBreedRepository breedRepository)
        => _breedRepository = breedRepository;

    public Task<Breed> Handle(GetBreedRequest request, CancellationToken cancellationToken)
        => _breedRepository.GetById(request.BreedId, cancellationToken);
}