# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia TODOS os arquivos da pasta raiz (GameAPI) para dentro do Docker
COPY . .

# Restaura as dependências apontando para o arquivo de projeto correto
# Usamos barras normais (/) pois o Docker roda em Linux
RUN dotnet restore "src/Backend/GameAPI.API/GameAPI.API.csproj"

# Compila e gera os arquivos finais na pasta /app/publish
RUN dotnet publish "src/Backend/GameAPI.API/GameAPI.API.csproj" -c Release -o /app/publish

# Estágio de Execução (Imagem Final)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

# O nome da DLL final segue o nome do seu projeto (.csproj)
ENTRYPOINT ["dotnet", "GameAPI.API.dll"]