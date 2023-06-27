namespace CatQL.Application
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Extension for the DI container to inject application-layer objects.</summary>
    public static class ServiceCollectionExtension
    {
        #region Methods

        /// <summary>Adds application-layer objects to the DI container.</summary>
        /// <param name="services">The DI container.</param>
        /// <returns>The extended DI container.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(o => o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        #endregion
    }
}