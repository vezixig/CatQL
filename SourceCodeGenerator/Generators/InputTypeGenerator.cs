using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SourceCodeGenerator.Generators;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Attributes;
using Extensions;
using GraphQL.Types;
using Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal class InputTypeGenerator : ISourceCodeGenerator
{
    public void Generate(Type sourceClassType)
    {
        var sourceClassName = sourceClassType.Name;
        var typeName = $"{sourceClassName}InputType";

        // Create a new compilation
        var compilationUnit = SF.CompilationUnit();

        // Create Namespace (with usings)
        var usingDirectives = CatQlSyntaxFactory.CreateUsings(new[] { "Core.Models", "global::GraphQL.Types" });
        var namespaceDeclaration = SF.NamespaceDeclaration(SF.IdentifierName("CatQL.Presentation.GraphQL.Types"))
            .AddUsings(usingDirectives);

        // Create class declaration
        var baseType = CatQlSyntaxFactory.CreateGenericBaseType(nameof(InputObjectGraphType), sourceClassName);
        var classDocumentation = SF.Comment($"/// <summary>GraphQL Type for <see cref=\"{sourceClassName}\"/></summary>");
        var classDeclaration = SF.ClassDeclaration(typeName)
            .WithBaseList(SF.BaseList(SF.SingletonSeparatedList<BaseTypeSyntax>(baseType)))
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithLeadingTrivia(SF.TriviaList(classDocumentation, SF.CarriageReturnLineFeed));

        // Create constructor 
        var constructorDocumentation = SF.Comment($"/// <summary>Initializes a new instance of the <see cref=\"{typeName}\"/> class.</summary>");
        var nameStatement = SF.ParseStatement($"Name = \"{sourceClassName}Input\";")
            .WithTrailingTrivia(CatQlSyntaxFactory.LineFeedTrivia);
        var constructorDeclaration = SF.ConstructorDeclaration(typeName)
            .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
            .WithBody(SF.Block(nameStatement))
            .WithLeadingTrivia(SF.TriviaList(constructorDocumentation, SF.CarriageReturnLineFeed));

        // Create type declarations
        var properties = sourceClassType.GetProperties();
        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<InputAttribute>() == null) continue;

            var description = property.GetCustomAttribute<DescriptionAttribute>();

            var fieldType = string.Empty;

            var isRequired = property.GetCustomAttribute<RequiredAttribute>() is not null;
            if (isRequired) fieldType += "NonNullGraphType<";

            if (property.PropertyType == typeof(string))
                fieldType += "StringGraphType";
            else if (property.PropertyType == typeof(int))
                fieldType += "IntGraphType";
            else if (property.PropertyType == typeof(DateTime))
                fieldType += "DateGraphType";
            else
                throw new ArgumentOutOfRangeException(nameof(property.PropertyType), $"Type {property.PropertyType.Name} is not supported by source generator");

            if (isRequired) fieldType += ">";

            var fieldSetup = SF.ParseStatement($"Field<{fieldType}>(\"{property.Name}\");")
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