namespace CatQL.Application.Handler;

using Core.Models;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Requests;

internal class CreateCatHandler : IRequestHandler<CreateCatRequest, Cat>
{
    private readonly ICatRepository _catRepository;

    public CreateCatHandler(ICatRepository catRepository)
        => _catRepository = catRepository;

    public async Task<Cat> Handle(CreateCatRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var result = await _catRepository.Create(request.Cat, cancellationToken);
        return result;
    }
}