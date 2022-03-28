FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY Services/Lookup.API/Lookup.API.csproj Services/Lookup.API/
RUN dotnet restore Services/Lookup.API/Lookup.API.csproj
COPY . .
WORKDIR /src/Services/Lookup.API
RUN dotnet build Lookup.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Lookup.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lookup.API.dll"]
