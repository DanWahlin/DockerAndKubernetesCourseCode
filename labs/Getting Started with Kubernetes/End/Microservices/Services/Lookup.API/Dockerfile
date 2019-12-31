FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk AS build
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
