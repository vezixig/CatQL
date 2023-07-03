namespace CatQL.Infrastructure.Repositories;

using Core.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

internal class CatRepository : ICatRepository
{
    private readonly DataContext _dataContext;

    public CatRepository(DataContext dataContext)
        => _dataContext = dataContext;

    public async Task<Cat> GetById(int id, CancellationToken cancellationToken)
        => await _dataContext.Cats.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<Cat> Create(Cat cat, CancellationToken cancellationToken)
    {
        var data = await _dataContext.Cats.AddAsync(cat, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return data.Entity;
    }
}