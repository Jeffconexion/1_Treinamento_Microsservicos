#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api.Discount/Api.Discount.csproj", "Api.Discount/"]
RUN dotnet restore "Api.Discount/Api.Discount.csproj"
COPY . .
WORKDIR "/src/Api.Discount"
RUN dotnet build "Api.Discount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Discount.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Discount.dll"]