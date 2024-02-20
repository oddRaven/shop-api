# Shop API

This project is made with C# .NET 8 and Entity Framework (EF) Core.

## Development

Follow these steps to setup the project for development:
1. Set TimoShopApi as startup project, because the EF database context is located here.
1. Open Tools -> NuGet Package Manager -> Package Manager Console.
1. Run `Update-Database` in the Package Manager Console.
1. Execute TimoShopApi -> Database -> Seed.sql.
