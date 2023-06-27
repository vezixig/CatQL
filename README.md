
# CatQL
A playground for creating a GraphQL API about cats

Ae ASP.NET GraphQL API endpoint utilizing a MySQL database for efficient data retrieval and manipulation.

## Useful Information

### EF Core migrations and updating the database
To create a new migration file based on the C# models, run the following command in a terminal window from the solution folder:

    dotnet ef migration add InitialMigration --project Infrastructure
Afterward, update the database with the migration using the following command:

    dotnet ef database update

[Read More](https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx)
