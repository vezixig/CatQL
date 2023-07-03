namespace CatQL.Presentation;

using System.Reflection;
using global::GraphQL;
using global::GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Schema = GraphQL.Schema.Schema;

/// <summary>Extension for the DI container to inject application-layer objects.</summary>
public static class ServiceCollectionExtension
{
    #region Methods

    /// <summary>Adds application-layer objects to the DI container.</summary>
    /// <param name="services">The DI container.</param>
    /// <returns>The extended DI container.</returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddGraphQL(
            b => b.AddSystemTextJson()
                .AddGraphTypes(Assembly.GetCallingAssembly()));

        services.AddScoped<ISchema, Schema>();
        //services.AddScoped<ISchema, BreedSchema>();
        return services;
    }

    #endregion
}