namespace CatQL.Application.Handler;

using MediatR;
using Requests;

internal class HealthCheckHandler : IRequestHandler<HealthCheckRequest>
{
    public Task Handle(HealthCheckRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}