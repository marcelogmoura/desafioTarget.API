# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["desafioTarget.API/desafioTarget.API.csproj", "desafioTarget.API/"]
COPY ["desafioTarget.Application/desafioTarget.Application.csproj", "desafioTarget.Application/"]
COPY ["desafioTarget.Domain/desafioTarget.Domain.csproj", "desafioTarget.Domain/"]
COPY ["desafioTarget.Infra/desafioTarget.Infra.csproj", "desafioTarget.Infra/"]
RUN dotnet restore "desafioTarget.API/desafioTarget.API.csproj"
COPY . .
WORKDIR "/src/desafioTarget.API"
RUN dotnet build "desafioTarget.API.csproj" -c Release -o /app/build

# Estágio de Publicação
FROM build AS publish
RUN dotnet publish "desafioTarget.API.csproj" -c Release -o /app/publish

# Estágio Final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "desafioTarget.API.dll"]