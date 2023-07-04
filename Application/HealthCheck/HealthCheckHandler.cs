namespace CatQL.Application.HealthCheck;

using MediatR;

internal class HealthCheckHandler : IRequestHandler<HealthCheckRequest>
{
    public Task Handle(HealthCheckRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}