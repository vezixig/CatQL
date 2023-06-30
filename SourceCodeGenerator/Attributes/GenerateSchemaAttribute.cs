namespace SourceCodeGenerator.Attributes
{
    using Enums;

    /// <summary>Attribute to mark a class as generation base for a schema.</summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GenerateSchemaAttribute : Attribute
    {
        public GenerateSchemaAttribute(SchemaOptions options)
            => Options = options;

        public SchemaOptions Options { get; }
    }
}