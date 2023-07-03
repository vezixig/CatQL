namespace SourceCodeGenerator.Enums;

[Flags]
public enum SchemaOptions
{
    None = 0,

    Query = 1,

    Mutation = 2,

    Subscription = 4
}