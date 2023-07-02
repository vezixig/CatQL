namespace SourceCodeGenerator.Generators;

using System.ComponentModel;
using System.Reflection;
using Attributes;
using Extensions;
using GraphQL.Types;
using Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

internal class OutputTypeGenerator : ISourceCodeGenerator
{
    public void Generate(Type sourceClassType)
    {
        var sourceClassName = sourceClassType.Name;
        var typeName = $"{sourceClassName}OutputType";

        // Create a new compilation
        var compilationUnit = SF.CompilationUnit();

        // Create Namespace (with usings)
        var usingDirectives = CatQlSyntaxFactory.CreateUsings(new[] { "Core.Models", "global::GraphQL.Types" });
        var namespaceDeclaration = SF.NamespaceDeclaration(SF.IdentifierName("CatQL.Presentation.GraphQL.Types"))
            .AddUsings(usingDirectives);

        // Create class declaration
        var baseType = CatQlSyntaxFactory.CreateGenericBaseType(nameof(ObjectGraphType), sourceClassName);
        var classDocumentation = SF.Comment($"/// <summary>GraphQL Type for <see cref=\"{sourceClassName}\"/></summary>");
        var classDeclaration = SF.ClassDeclaration(typeName)
            .WithBaseList(SF.BaseList(SF.SingletonSeparatedList<BaseTypeSyntax>(baseType)))
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithLeadingTrivia(SF.TriviaList(classDocumentation, SF.CarriageReturnLineFeed));

        // Create constructor 
        var constructorDocumentation = SF.Comment($"/// <summary>Initializes a new instance of the <see cref=\"{typeName}\"/> class.</summary>");
        var constructorDeclaration = SF.ConstructorDeclaration(typeName)
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithBody(SF.Block())
            .WithLeadingTrivia(SF.TriviaList(constructorDocumentation, SF.CarriageReturnLineFeed));

        // Create type declarations
        var properties = sourceClassType.GetProperties();
        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<OutputAttribute>() == null) continue;

            var description = property.GetCustomAttribute<DescriptionAttribute>();
            var fieldSetup = SF.ParseStatement($"Field(o => o.{property.Name}).Description(\"{description?.Description ?? property.Name}\");")
                .WithTrailingTrivia(CatQlSyntaxFactory.LineFeedTrivia);
            constructorDeclaration = constructorDeclaration.AddBodyStatements(fieldSetup);
        }

        // Add constructor to class
        classDeclaration = classDeclaration.AddMembers(constructorDeclaration);

        // Add class to namespace
        namespaceDeclaration = namespaceDeclaration.AddMembers(classDeclaration);

        // Add namespace to the compilation
        compilationUnit = compilationUnit.AddMembers(namespaceDeclaration)
            .WithLeadingTrivia(CatQlSyntaxFactory.GetHeader(sourceClassType));


        compilationUnit.WriteToFile($"../../../../Presentation/GraphQL/Types/{typeName}.cs");
    }
}