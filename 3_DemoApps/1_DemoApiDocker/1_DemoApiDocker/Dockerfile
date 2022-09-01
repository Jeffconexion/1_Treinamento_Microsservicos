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
#Stagio 1 - Publish
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build #build é o nome do estágio
#
## Define o diretório de trabalho de um contêiner do docker a qualquer momento.
#WORKDIR /src
#COPY 1_DemoApiDocker.csproj .
#RUN dotnet restore
#COPY . .
#RUN dotnet publish -c release -o /app
#
##Stagio 2 - Production
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 
#WORKDIR /app
#COPY --from=build /app .  #passando informações entre os diferentes estágios
#
## Informa ao docker para configurar o contêiner para ser executado como um executável.
#ENTRYPOINT ["dotnet", "1_DemoApiDocker.dll"]


#Docker FILE OTIMIZADO
# ~~> STAGE 1- BASE
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base 
WORKDIR /src
EXPOSE 80
EXPOSE 443

# ~~> STAGE 2- PUBLISH
FROM mcr.microsoft.com/dotnet/sdk:5.0  AS publish
WORKDIR /src
COPY 1_DemoApiDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /dist

# ~~> STAGE 3- END
FROM base AS end
WORKDIR /dist
COPY --from=publish /dist . 
ENTRYPOINT ["dotnet", "1_DemoApiDocker.dll"]
