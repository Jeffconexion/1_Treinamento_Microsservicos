
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Catalog.Api/Catalog.Api.csproj", "Catalog.Api/"]
COPY ["Catalog.Infraestructure/Catalog.Infraestructure.csproj", "Catalog.Infraestructure/"]
COPY ["Catalog.Core/Catalog.Core.csproj", "Catalog.Core/"]
RUN dotnet restore "Catalog.Api/Catalog.Api.csproj"
COPY . .
WORKDIR "/src/Catalog.Api"
RUN dotnet build "Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]
