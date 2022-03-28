FROM        mcr.microsoft.com/dotnet/sdk:5.0
LABEL       author="Your Name"

ENV         ASPNETCORE_URLS=http://*:3000
ENV         DOTNET_USE_POLLING_FILE_WATCHER=1
ENV         ASPNETCORE_ENVIRONMENT=development

EXPOSE      3000

WORKDIR     /app

CMD         ["dotnet restore && dotnet build && dotnet watch run"]




# Run the following:
# 1. docker build -f windows.dev.dockerfile -t aspnetcore-dev .  
# 2. docker run -p 3000:3000 -v %cd%:/app aspnetcore-dev
# 3. Visit http://localhost:3000 in the browser.


