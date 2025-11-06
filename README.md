# GameAPI

> API interativa, que permite adicionar players e experiência aos mesmos, e também deleta-los caso deseje.

---
### Esta API foi criada com objetivo de demonstrar experiência com o assunto e boas práticas de desenvolvimento incluindo:

- **Domain Drive Design (DDD)** 
- **Arquitetura em camadas** 
---
### Tecnologias utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core** (com MySQL)
- **FluentMigrator**
- **Dapper**
- **Git/GitHub**
---
### Pré-requisitos
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download/dotnet/8.0)
- **MySQL 8.0+**
---
### EndPoints

| Método | EndPoint | Descrição |
|----------------------------------|---------------------------------|---------------------------------|
| Get | /api/Players | Lista todos os registros |
| Get | /api/Players/{id} | Retorna um registro específico |
| Post | /api/Players | Cria um novo player |
| Post | /api/Players/{id}/gain-xp | Adiciona experiência ao player selecionado |
| Delete | /api/Players{id}/remove | Remove o player selecionado |



