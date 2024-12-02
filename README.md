# exercise-db-connection+

A system to allow users to write a review for bboks (referenced from another repo).

Learn how to setup a project using a cloud database and EF Core

## steps:

- create new project

  `dotnet new mvc`

- install EF core using sql server or any other

  `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`

  `dotnet add package Microsoft.EntityFrameworkCore.Design`

- create the db on a cloud provider (es. Azure sql db)
- create classes in the data access layer
- install tools

  `dotnet tool install --global dotnet-ef`

  `dotnet add package Microsoft.EntityFrameworkCore.Tools`

- create appDbContext
- create appDbContextFactory that will be used by dotnet-ef tools

- run initial migration
  `dotnet ef migrations add InitialCreate`

- run the db update
  `dotnet ef database update`

- to secure the connection strings you can run
  `dotnet user-secrets init` and
  `dotnet user-secrets set "ConnectionStrings:<ConnectionName>" "<ConnectionStringValue>"`

## local testing commands

- clone/fork the repo
- db access is locked via ip, contact the admin
