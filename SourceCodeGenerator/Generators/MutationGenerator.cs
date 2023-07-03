namespace SourceCodeGenerator.Generators;

using System.Reflection;
using Attributes;
using Enums;
using Extensions;
using GraphQL.Types;
using Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

internal class MutationGenerator : ISourceCodeGenerator
{
    public void Generate(Type sourceClassType)
    {
        var generateAttribute = sourceClassType.GetCustomAttribute<GenerateSchemaAttribute>();
        if (generateAttribute == null || !generateAttribute.Options.HasFlag(SchemaOptions.Mutation)) return;

        var sourceClassName = sourceClassType.Name;
        var mutationName = sourceClassName + "Mutation";

        // Check if mutation class was already created
        if (File.Exists($"../../../../Presentation/GraphQL/Mutations/{mutationName}.cs")) return;

        // Create a new compilation
        var compilationUnit = SF.CompilationUnit();

        // Create namespace (with usings)
        var usingDirectives = CatQlSyntaxFactory.CreateUsings(new[] { "Core.Models", "global::GraphQL.Types" });
        var namespaceDeclaration = SF.NamespaceDeclaration(SF.IdentifierName("CatQL.Presentation.GraphQL.Mutations"))
            .AddUsings(usingDirectives);

        // Create class declaration
        var baseType = CatQlSyntaxFactory.CreateGenericBaseType(nameof(ObjectGraphType), sourceClassName);
        var classDocumentation = SF.Comment($"/// <summary>GraphQL mutation to create <see cref=\"{sourceClassName}\"/></summary>");
        var classDeclaration = SF.ClassDeclaration(mutationName)
            .WithBaseList(SF.BaseList(SF.SingletonSeparatedList<BaseTypeSyntax>(baseType)))
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithLeadingTrivia(SF.TriviaList(classDocumentation, SF.CarriageReturnLineFeed));

        // Add class to namespace
        namespaceDeclaration = namespaceDeclaration.AddMembers(classDeclaration);

        // Add namespace to the compilation
        compilationUnit = compilationUnit.AddMembers(namespaceDeclaration);

        compilationUnit.WriteToFile($"../../../../Presentation/GraphQL/Mutations/{mutationName}.cs");
    }
}