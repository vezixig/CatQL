namespace CatQL.Infrastructure.Repositories.Interfaces;

using Core.Models;

public interface IBreedRepository
{
    public Task<Breed> GetById(int id, CancellationToken cancellationToken);

    public Task<Breed> Create(Breed breed, CancellationToken cancellationToken);
}