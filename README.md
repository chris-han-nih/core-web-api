Dotnet core web api example
---

## Create a new project
```bash
dotnet new webapi -o <project_name>
```

## Run the project
```bash
dotnet run
```

## DB Migration
```bash
dotnet ef migrations add <migration_name>
dotnet ef database update
```