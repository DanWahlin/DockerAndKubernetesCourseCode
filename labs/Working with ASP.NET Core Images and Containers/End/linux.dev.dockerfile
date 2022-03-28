FROM        mcr.microsoft.com/dotnet/sdk:5.0
LABEL       author="Your Name"

ENV         ASPNETCORE_URLS=http://+:3000
ENV         DOTNET_USE_POLLING_FILE_WATCHER=1
ENV         ASPNETCORE_ENVIRONMENT=development

EXPOSE      3000
WORKDIR     /app

ENTRYPOINT ["/bin/bash", "-c","dotnet restore && dotnet watch run"]




# Run the following:
# 1. docker build -f linux.dev.dockerfile -t aspnetcore-dev .

#### Windows   
# Leave out the -d switch below if you want to see the container log output immediately
# 2. docker run -p 3000:3000 -v %cd%:/app aspnetcore-dev

#### Mac:   
# Leave out the -d switch below if you want to see the container log output immediately   
# 2. docker run -d -p 3000:3000 -v $(pwd):/app aspnetcore-dev

# 3. A container ID will be displayed
# 4. docker logs [first 3 characters of containerID from previous step]
# 5. Once the logs show that the server is running (you may have to run the
#    "docker logs" command multiple times), visit http://localhost:3000



