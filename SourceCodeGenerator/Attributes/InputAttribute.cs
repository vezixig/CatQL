﻿namespace SourceCodeGenerator.Attributes
{
    /// <summary>Attribute to mark properties as possible GraphQL input parameter for code generation.</summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class InputAttribute : Attribute
    {
    }
}