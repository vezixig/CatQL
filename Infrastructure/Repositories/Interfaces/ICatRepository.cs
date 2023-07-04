namespace CatQL.Infrastructure.Repositories.Interfaces;

using Core.Models;

public interface ICatRepository
{
    public Task<Cat> GetById(int id, CancellationToken cancellationToken);

    public Task<List<Cat>> GetAll(CancellationToken cancellationToken);


    public Task<Cat> Create(Cat data, CancellationToken cancellationToken);
}