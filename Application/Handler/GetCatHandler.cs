namespace CatQL.Application.Handler
{
    using Core.Models;
    using Infrastructure.Repositories;
    using MediatR;
    using Requests;

    internal class GetCatHandler : IRequestHandler<GetCatRequest, Cat>
    {
        private readonly CatRepository _catRepository;

        public GetCatHandler(CatRepository catRepository)
            => _catRepository = catRepository;

        public async Task<Cat> Handle(GetCatRequest request, CancellationToken cancellationToken)
        {
            var cat = await _catRepository.GetCatByIdAsync(request.Id, cancellationToken);

            if (cat == null) throw new KeyNotFoundException($"No cat with the id {request.Id} was found.");

            return cat;
        }
    }
}