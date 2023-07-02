using System.Diagnostics;
using System.Reflection;
using SourceCodeGenerator.Attributes;
using SourceCodeGenerator.Enums;
using SourceCodeGenerator.Generators;

if (!Debugger.IsAttached) Debugger.Launch();

var coreAssembly = Assembly.LoadFrom("../../../../Core/bin/Debug/net7.0/Core.dll");

foreach (var assemblyClass in coreAssembly.GetTypes())
{
    if (assemblyClass.IsClass == false) continue;
    if (assemblyClass.GetCustomAttributes(typeof(GenerateSchemaAttribute), true).Length == 0) continue;

    Console.WriteLine($"Generating sources for model class {assemblyClass.FullName}");

    Console.WriteLine("\tGenerating schema...");
    var schemaGenerator = new SchemaGenerator();
    schemaGenerator.Generate(assemblyClass);

    if (assemblyClass.GetCustomAttribute<GenerateSchemaAttribute>()?.Options.HasFlag(SchemaOptions.Query) == true)
    {
        Console.WriteLine("\tGenerating output type...");
        var typeGenerator = new OutputTypeGenerator();
        typeGenerator.Generate(assemblyClass);
    }

    if (assemblyClass.GetCustomAttribute<GenerateSchemaAttribute>()?.Options.HasFlag(SchemaOptions.Mutation) == true)
    {
        Console.WriteLine("\tGenerating input type...");
        var inputTypeGenerator = new InputTypeGenerator();
        inputTypeGenerator.Generate(assemblyClass);
    }

    Console.WriteLine("\tGenerating query...");
    // todo

    Console.WriteLine("\tGenerating mutation...");
    // todo
}


Console.WriteLine("Press RETURN to exit");
Console.ReadLine();