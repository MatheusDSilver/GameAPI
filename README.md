# GameAPI

Este repositório contém uma API RESTful construída com ASP.NET CORE, cuja estrutura segue o padrão Clean Architecture.

Criei esta API para praticar os princípios fundamentais na construção de APIs robustas. O projeto ainda está em andamento, evoluindo conforme aplico novos conceitos e boas práticas.

O tema voltado a jogos foi escolhido para tornar o projeto mais leve e menos sério, fugindo do padrão tradicional de APIs presentes na maioria dos portfólios.

## Tecnologias e conceitos utilizados

- **Clean Architecture** 
- **Domain Driven Design (DDD)**
- **Containerização do projeto via Docker** 
- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core** (com MySQL)
- **FluentMigrator**
- **Projeto versionado com Git e GitHub**
- **Pipelines no GitHub Actions**

## Executando o projeto

Essa API está **conteinerizada** então está fácil de executar 😉

> Para executar a aplicação, certifique-se de ter o [Docker](https://www.docker.com/):


### 1. Clone o repositório
>git clone [https://github.com/MatheusDSilver/GameAPI.git](https://github.com/MatheusDSilver/GameAPI.git)


### 2. Suba o ambiente (API + Banco de Dados)
```bash
docker compose up --build
```

### Como Acessar

Após rodar o comando do Docker e aguardar a inicialização, a API estará disponível em:

 **[Abrir Swagger UI (http://localhost:5000/swagger)](http://localhost:5000/swagger)**

**Nota:** Se o link não abrir imediatamente, aguarde alguns segundos para o container do banco de dados finalizar a configuração inicial.


---
## EndPoints

| Método | EndPoint | Descrição |
|----------------------------------|---------------------------------|---------------------------------|
| GET | /api/Players | Lista todos os jogadores |
| GET | /api/Players/{id} | Retorna um registro específico |
| POST | /api/Players | Cria um novo player |
| POST | /api/Players/{id}/gain-xp | (Regra de Negócio) Adiciona XP e recalcula o nível do jogador |
| DELETE | /api/Players/{id} | Remove um jogador do banco |
---