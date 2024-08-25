#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8680 
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SistemaDeMercado/ApiProdutos.csproj", "SistemaDeMercado/"]
COPY ["Aplication/Aplication.csproj", "Aplication/"]
COPY ["ConnectionSql/ConnectionSql.csproj", "ConnectionSql/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "./SistemaDeMercado/ApiProdutos.csproj"
COPY . .
WORKDIR "/src/SistemaDeMercado"
RUN dotnet build "./ApiProdutos.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiProdutos.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiProdutos.dll"]