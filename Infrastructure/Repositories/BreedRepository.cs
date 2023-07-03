namespace CatQL.Infrastructure.Repositories;

using Core.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

internal class BreedRepository : IBreedRepository
{
    private readonly DataContext _dataContext;

    public BreedRepository(DataContext dataContext)
        => _dataContext = dataContext;

    public async Task<Breed> GetById(int id, CancellationToken cancellationToken)
    {
        var data = await _dataContext.Breeds.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        return data ?? throw new KeyNotFoundException($"{nameof(id)} {id} not found");
    }

    public async Task<Breed> Create(Breed breed, CancellationToken cancellationToken)
    {
        var data = await _dataContext.Breeds.AddAsync(breed, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return data.Entity;
    }
}