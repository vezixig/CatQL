using System.Diagnostics;
using System.Reflection;
using SourceCodeGenerator.Attributes;
using SourceCodeGenerator.Enums;
using SourceCodeGenerator.Generators;

if (!Debugger.IsAttached) Debugger.Launch();

var coreAssembly = Assembly.LoadFrom("../../../../Core/bin/Debug/net7.0/Core.dll");

var schemaGenerator = new SchemaGenerator();
var outputTypeGenerator = new OutputTypeGenerator();
var queryGenerator = new QueryGenerator();
var inputTypeGenerator = new InputTypeGenerator();
var mutationGenerator = new MutationGenerator();

foreach (var assemblyClass in coreAssembly.GetTypes())
{
    if (assemblyClass.IsClass == false) continue;
    var generateAttribute = assemblyClass.GetCustomAttribute<GenerateSchemaAttribute>();
    if (generateAttribute == null) continue;

    Console.WriteLine($"Generating sources for model class {assemblyClass.FullName}");

    Console.WriteLine("\tGenerating schema...");
    schemaGenerator.Generate(assemblyClass);

    if (generateAttribute.Options.HasFlag(SchemaOptions.Query))
    {
        Console.WriteLine("\tGenerating output type...");
        outputTypeGenerator.Generate(assemblyClass);

        Console.WriteLine("\tGenerating query...");
        queryGenerator.Generate(assemblyClass);
    }

    if (generateAttribute.Options.HasFlag(SchemaOptions.Mutation))
    {
        Console.WriteLine("\tGenerating input type...");
        inputTypeGenerator.Generate(assemblyClass);

        Console.WriteLine("\tGenerating mutation...");
        mutationGenerator.Generate(assemblyClass);
    }
}