# Template generate for visual studio.
# the next command(1) only it's work if the root father
# 1 - Create image: docker build -t demoapiteste:1.0 -f 1_DemoApiDocker/Dockerfile .
# 2 - Next command I create container propt windos 
# 3 - Create container: docker container run -it --rm -p 3000:80 --name democontainer apimicrosservice:1.0
# 4 - Acess url: http://localhost:3000/weatherforecast

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["1_DemoApiDocker/1_DemoApiDocker.csproj", "1_DemoApiDocker/"]
#RUN dotnet restore "1_DemoApiDocker/1_DemoApiDocker.csproj"
#COPY . .
#WORKDIR "/src/1_DemoApiDocker"
#RUN dotnet build "1_DemoApiDocker.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "1_DemoApiDocker.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "1_DemoApiDocker.dll"]


# My template.
# 1 - Create image: docker build -t apimicrosservice:1.0 .
# 2 - Next command I create container propt windos 
# 3 - Create container: docker container run -it --rm -p 3000:80 --name democontainer apimicrosservice:1.0
# 4 - Acess url: http://localhost:3000/weatherforecast

#Cria uma net core sdk 5.0
#Cada from é um novo estágio que substitui o anterior
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Define o diretório de trabalho de um contêiner do docker a qualquer momento.
WORKDIR /src
COPY 1_DemoApiDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /app
COPY --from=build /app .

# Informa ao docker para configurar o contêiner para ser executado como um executável.
ENTRYPOINT ["dotnet", "1_DemoApiDocker.dll"]
