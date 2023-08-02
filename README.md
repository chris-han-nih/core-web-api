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
---
## CodeFirst 처음 살펴보기
### MinLength and MaxLength
> MaxLength가 데이터베이스와 대응 관계에 있는 반면 MinLength는 그렇지 않다. MinLength는 엔티티 프레임워크의 유효성 검사에 사용된다. 하지만 데이터베이스에 영향을 주지는 않는다.
> MinLength는 데이터 어노테이션을 사용해 수행될 수 있는 유일한 설정이지만 플루언트 API 설정과는 어떠한 대응 관계도 갖지 않는다.
> 
