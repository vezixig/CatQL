
# CatQL
A playground for creating a GraphQL API about cats

Ae ASP.NET GraphQL API endpoint utilizing a MySQL database for efficient data retrieval and manipulation.
## Used Packages
This project is using the following packages:

[GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet)

[MediatR](https://github.com/jbogard/MediatR)

[Microsoft.EntityFrameworkCore](https://github.com/dotnet/efcore)

[Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)

Big thanks to all the developers and supporters of this projects!

## Useful Information

### EF Core migrations and updating the database
To create a new migration file based on the C# models, run the following command in a terminal window from the solution folder:

    dotnet ef migrations add InitialMigration --project Infrastructure
Afterward, update the database with the migration using the following command:

    dotnet ef database update --project Infrastructure

[Read More](https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx)

### Startup
After starting the Service GraphQL can be accessed through this URL:
https://localhost:7023/graphql

