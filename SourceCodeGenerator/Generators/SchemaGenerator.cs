namespace SourceCodeGenerator.Generators;

using System.Reflection;
using Attributes;
using Enums;
using Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

internal class SchemaGenerator : ISourceCodeGenerator
{
    public void Generate(Type sourceClassType)
    {
        var generateAttribute = sourceClassType.GetCustomAttribute<GenerateSchemaAttribute>();
        if (generateAttribute == null) return;

        var sourceClassName = sourceClassType.Name;
        var schemaName = sourceClassName + "Schema";


        // Create a new compilation
        var compilationUnit = SF.CompilationUnit();


        // Namespace (with usings)
        var usingDirectives = CatQlSyntaxFactory.CreateUsings(new[] { "global::GraphQL.Types", "Core.Models", "MediatR", "Queries" });
        var namespaceDeclaration = SF.NamespaceDeclaration(SF.IdentifierName("CatQL.Presentation.GraphQL.Schema"))
            .AddUsings(usingDirectives);

        // Add public class declaration
        var classDocumentation = SF.Comment($"/// <summary>GraphQL Schema for <see cref=\"{sourceClassName}\"/></summary>");
        var baseClass = SF.SingletonSeparatedList<BaseTypeSyntax>(SF.SimpleBaseType(SF.ParseTypeName("Schema")));
        var classDeclaration = SF.ClassDeclaration(schemaName)
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithBaseList(SF.BaseList(baseClass))
            .WithLeadingTrivia(SF.TriviaList(classDocumentation, SF.CarriageReturnLineFeed));

        // Create a constructor declaration
        var constructorDocumentation = SF.Comment($"/// <summary>Initializes a new instance of the <see cref=\"{schemaName}\"/> class.</summary>");
        var constructorParameterDocumentation = SF.Comment("/// <param name=\"mediator\">An implementation of <see cref=\"IMediator\"/>.</param>");
        var constructorParameterList = SF.ParameterList(
            SF.SingletonSeparatedList(
                SF.Parameter(SF.Identifier("mediator"))
                    .WithType(SF.ParseTypeName("IMediator"))));
        var constructorDeclaration = SF.ConstructorDeclaration(schemaName)
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithBody(SF.Block())
            .WithLeadingTrivia(
                SF.TriviaList(
                    constructorDocumentation,
                    SF.CarriageReturnLineFeed,
                    constructorParameterDocumentation,
                    SF.CarriageReturnLineFeed))
            .WithParameterList(constructorParameterList);

        // Add statements to the constructor body
        if (generateAttribute.Options.HasFlag(SchemaOptions.Query))
        {
            var queryStatement = SF.ParseStatement($"Query = new {sourceClassName}Query(mediator);").WithTrailingTrivia(CatQlSyntaxFactory.LineFeedTrivia);
            constructorDeclaration = constructorDeclaration.AddBodyStatements(queryStatement);
        }

        if (generateAttribute.Options.HasFlag(SchemaOptions.Mutation))
        {
            var mutatorStatement = SF.ParseStatement($"Mutation = new {sourceClassName}Mutation(mediator);");
            constructorDeclaration = constructorDeclaration.AddBodyStatements(mutatorStatement);
        }

        // Add the constructor declaration to the class declaration
        classDeclaration = classDeclaration.AddMembers(constructorDeclaration);

        // Add class to namespace
        namespaceDeclaration = namespaceDeclaration.AddMembers(classDeclaration);

        // Add namespace to the compilation
        compilationUnit = compilationUnit.AddMembers(namespaceDeclaration)
            .WithLeadingTrivia(CatQlSyntaxFactory.GetHeader(sourceClassType));

        // Create syntax tree
        var syntaxTree2 = CSharpSyntaxTree.Create(compilationUnit);

        // Get the root of the syntax tree
        var resultRoot = syntaxTree2.GetRoot();

        // Format the syntax tree
        var formattedRoot = Formatter.Format(resultRoot, new AdhocWorkspace());
        var fileContent = formattedRoot.ToFullString();

        // Write to file
        var filePath = $"../../../../Presentation/GraphQL/Schema/{schemaName}.cs";
        File.Create(filePath).Dispose();
        File.WriteAllText(filePath, fileContent);
    }
}