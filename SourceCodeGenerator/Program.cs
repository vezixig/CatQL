using System.Diagnostics;
using System.Reflection;
using CatQL.Core.Attributes;
using SourceCodeGenerator.Generators;

if (!Debugger.IsAttached) Debugger.Launch();

var coreAssembly = Assembly.Load("Core");

foreach (var assemblyClass in coreAssembly.GetTypes())
{
    if (assemblyClass.IsClass == false) continue;
    if (assemblyClass.GetCustomAttributes(typeof(GenerateSchemaAttribute), true).Length == 0) continue;

    Console.WriteLine($"Generating sources for model class {assemblyClass.FullName}");

    Console.WriteLine("\tGenerating schema...");
    var schemaGenerator = new SchemaGenerator();
    schemaGenerator.Generate(assemblyClass);

    Console.WriteLine("\tGenerating type...");
    // todo

    Console.WriteLine("\tGenerating input type...");
    // todo

    Console.WriteLine("\tGenerating query...");
    // todo

    Console.WriteLine("\tGenerating mutation...");
    // todo
}


Console.WriteLine("Press RETURN to exit");
Console.ReadLine();