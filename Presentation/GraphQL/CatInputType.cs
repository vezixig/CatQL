﻿namespace CatQL.Presentation.GraphQL;

using global::GraphQL.Types;

public sealed class CatInputType : InputObjectGraphType
{
    /// <summary>Initializes a new instance of the <see cref="CatInputType" /> class.</summary>
    public CatInputType()
    {
        Name = "CatInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<IntGraphType>>("age");
        Field<NonNullGraphType<IntGraphType>>("weight");
        Field<DateGraphType>("birthdate");
        Field<NonNullGraphType<StringGraphType>>("color");
    }
}