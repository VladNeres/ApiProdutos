#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SistemaDeMercado/SistemaDeMercado.csproj", "SistemaDeMercado/"]
COPY ["Aplication/Aplication.csproj", "Aplication/"]
COPY ["ConnectionSql/ConnectionSql.csproj", "ConnectionSql/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "SistemaDeMercado/SistemaDeMercado.csproj"
COPY . .
WORKDIR "/src/SistemaDeMercado"
RUN dotnet build "SistemaDeMercado.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaDeMercado.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaDeMercado.dll"]