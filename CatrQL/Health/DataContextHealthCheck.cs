namespace CatQL.Infrastructure.Health;

using Application.Requests;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class DataContextHealthCheck : IHealthCheck
{
    private readonly DataContext _dataContext;

    private readonly IMediator _mediator;

    public DataContextHealthCheck(IMediator mediator, DataContext dataContext)
    {
        _mediator = mediator;
        _dataContext = dataContext;
    }


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