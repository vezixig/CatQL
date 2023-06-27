namespace CatQL.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

    /// <summary>Extension for the DI container to inject application-layer objects.</summary>
    public static class ServiceCollectionExtension
    {
        #region Methods

        /// <summary>Adds application-layer objects to the DI container.</summary>
        /// <param name="services">The DI container.</param>
        /// <returns>The extended DI container.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<CatRepository>();
            return services;
        }

        #endregion
    }
}