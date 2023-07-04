namespace CatQL.Health;

using Application.HealthCheck;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class DataContextHealthCheck : IHealthCheck
{
    private readonly IMediator _mediator;

    public DataContextHealthCheck(IMediator mediator)
        => _mediator = mediator;


    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
    {
        try
        {
            await _mediator.Send(new HealthCheckRequest(), cancellationToken);
            return HealthCheckResult.Healthy();
        }
        catch (Exception ex) { return HealthCheckResult.Unhealthy(exception: ex); }
    }
}