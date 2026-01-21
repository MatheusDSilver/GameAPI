# GameAPI

> Este repositório contém uma API RESTful construída com ASP.NET CORE, cuja estrutura segue o padrão Clean Architecture.

---
## Criei esta API para praticar os princípios fundamentais na construção de APIs robustas. O projeto ainda está em andamento, evoluindo conforme aplico novos conceitos e boas práticas.

## O tema voltado a jogos foi escolhido para tornar o projeto mais leve e menos sério, fugindo do padrão tradicional de APIs presentes na maioria dos portfólios.

### Tecnologias e conceitos utilizados

- **Clean Architecture** 
- **Domain Driven Design (DDD)**
- **Containerização do projeto via Docker** 
- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core** (com MySQL)
- **FluentMigrator**
- **Projeto versionado com Git e GitHub**
- **Pipelines no GitHub Actions**
---
### EndPoints

| Método | EndPoint | Descrição |
|----------------------------------|---------------------------------|---------------------------------|
| GET | /api/Players | Lista todos os registros |
| GET | /api/Players/{id} | Retorna um registro específico |
| POST | /api/Players | Cria um novo player |
| POST | /api/Players/{id}/gain-xp | Adiciona experiência ao player selecionado |
| DELETE | /api/Players/{id} | Remove o player selecionado |



