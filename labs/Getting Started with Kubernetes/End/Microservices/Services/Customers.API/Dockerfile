FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY Services/Customers.API/Customers.API.csproj Services/Customers.API/
RUN dotnet restore Services/Customers.API/Customers.API.csproj
COPY . .
WORKDIR /src/Services/Customers.API
RUN dotnet build Customers.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Customers.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Customers.API.dll"]
