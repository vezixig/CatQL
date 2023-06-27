namespace CatQL.Core.Attributes
{
    /// <summary>Attribute to mark a class as generation base for a schema.</summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GenerateSchemaAttribute : Attribute
    {
    }
}