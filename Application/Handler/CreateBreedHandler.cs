namespace CatQL.Application.Handler;

using Core.Models;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Requests;

internal class CreateBreedHandler : IRequestHandler<CreateBreedRequest, Breed>
{
    private readonly IBreedRepository _breedRepository;

    public CreateBreedHandler(IBreedRepository breedRepository)
        => _breedRepository = breedRepository;

    public async Task<Breed> Handle(CreateBreedRequest request, CancellationToken cancellationToken)
    {
        var data = await _breedRepository.Create(request.Breed, cancellationToken);
        return data;
    }
}