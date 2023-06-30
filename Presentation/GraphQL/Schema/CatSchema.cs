//----------------------
// <auto-generated>
//      Generated by the SourceCodeGenerator project. DO NOT EDIT!
//      source: CatQL.Core.Models.Cat
// </auto-generated>
//----------------------

namespace CatQL.Presentation.GraphQL.Schema
{
    using global::GraphQL.Types;
    using Core.Models;
    using MediatR;
    using Queries;

    /// <summary>GraphQL Schema for <see cref="Cat"/></summary>
    public class CatSchema : Schema
    {
        /// <summary>Initializes a new instance of the <see cref="CatSchema"/> class.</summary>
        public CatSchema(IMediator mediator)
        {
            Query = new CatQuery(mediator);
            Mutation = new CatMutation(mediator);
        }
    }
}