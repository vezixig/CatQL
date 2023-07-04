namespace CatQL.Application.Data.Cat;

using Core.Models;
using Infrastructure.Repositories.Interfaces;
using MediatR;

internal class GetCatsHandler : IRequestHandler<GetCatsRequest, List<Cat>>
{
    private readonly ICatRepository _catRepository;

    public GetCatsHandler(ICatRepository catRepository)
        => _catRepository = catRepository;

    public Task<List<Cat>> Handle(GetCatsRequest request, CancellationToken cancellationToken)
        => _catRepository.GetAll(cancellationToken);
}