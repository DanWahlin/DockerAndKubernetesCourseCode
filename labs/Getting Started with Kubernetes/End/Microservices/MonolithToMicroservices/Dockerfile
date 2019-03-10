FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MonolithToMicroservices/MonolithToMicroservices.csproj MonolithToMicroservices/
RUN dotnet restore MonolithToMicroservices/MonolithToMicroservices.csproj
COPY . .
WORKDIR /src/MonolithToMicroservices
RUN dotnet build MonolithToMicroservices.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MonolithToMicroservices.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MonolithToMicroservices.dll"]
