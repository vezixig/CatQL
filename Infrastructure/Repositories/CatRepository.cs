namespace CatQL.Infrastructure.Repositories
{
    using Core.Models;
    using Microsoft.EntityFrameworkCore;

    public class CatRepository
    {
        private readonly DataContext _dataContext;

        public CatRepository(DataContext dataContext)
            => _dataContext = dataContext;

        public async Task<Cat> GetCatByIdAsync(int id, CancellationToken cancellationToken)
            => await _dataContext.Cats.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
}