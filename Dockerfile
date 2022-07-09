#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY StatesNLgas/*.csproj StatesNLgas/
RUN dotnet restore StatesNLgas/*.csproj
COPY . .
WORKDIR /src/StatesNLgas
RUN dotnet build

FROM build AS publish
WORKDIR /src/StatesNLgas

RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish src/StatesNLgas/Json/lgas.json json/
COPY --from=publish src/StatesNLgas/Json/states.json json/
COPY --from=publish src/StatesNLgas/Json/states_lgas.json json/

#ENTRYPOINT ["dotnet", "StatesNLgas.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet StatesNLgas.dll