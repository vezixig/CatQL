namespace SourceCodeGenerator.Generators
{
    using Interfaces;

    internal class TypeGenerator : ISourceCodeGenerator
    {
        public void Generate(Type sourceClassType)
        {
            // Write to file
            var filePath = $"../../../../Presentation/GraphQL/Types/{typeName}.cs";
            File.Create(filePath).Dispose();
            File.WriteAllText(filePath, fileContent2);
        }
    }
}