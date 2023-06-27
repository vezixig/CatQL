namespace CatQL.Core
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Extension for the DI container to inject core-layer objects.</summary>
    public static class ServiceCollectionExtension
    {
        #region Methods

        /// <summary>Adds core-layer objects to the DI container.</summary>
        /// <param name="services">The DI container.</param>
        /// <returns>The extended DI container.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services;

        #endregion
    }
}