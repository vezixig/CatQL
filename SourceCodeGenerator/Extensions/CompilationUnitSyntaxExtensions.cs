namespace SourceCodeGenerator.Extensions
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;

    internal static class CompilationUnitSyntaxExtensions
    {
        public static void WriteToFile(this CompilationUnitSyntax unit, string filePath)
        {
            // Create syntax tree
            var syntaxTree2 = CSharpSyntaxTree.Create(unit);

            // Get the root of the syntax tree
            var resultRoot = syntaxTree2.GetRoot();

            // Format the syntax tree
            var formattedRoot = Formatter.Format(resultRoot, new AdhocWorkspace());
            var fileContent = formattedRoot.ToFullString();

            // Write to file
            File.Create(filePath).Dispose();
            File.WriteAllText(filePath, fileContent);
        }
    }
}