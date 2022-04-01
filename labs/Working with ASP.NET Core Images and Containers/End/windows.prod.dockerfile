FROM        mcr.microsoft.com/dotnet/aspnet:5.0
LABEL       author="Your Name"

ENV         ASPNETCORE_URLS=http://*:3000
ENV         ASPNETCORE_ENVIRONMENT=production

EXPOSE      3000

WORKDIR     /app

COPY        ./dist /app

ENTRYPOINT  ["dotnet", "ASPNET-Core-Docker.dll"]




# Run the following:
# 1. dotnet restore
# 2. dotnet build
# 3. dotnet publish -c Release -o dist
# 4. docker build -f windows.prod.dockerfile -t aspnetcore-prod . 
# 5. docker run -p 3000:3000 aspnetcore-prod
# 6. Visit http://[containerIP]:3000 in the browser.