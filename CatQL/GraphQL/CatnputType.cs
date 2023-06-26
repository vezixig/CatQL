namespace API.GraphQL;

using global::GraphQL.Types;

public class CatInputType : InputObjectGraphType
{
    public CatInputType()
    {
        Name = "CatInput";
        Field<NonNullGraphType<StringGraphType>>("name");
    }
}