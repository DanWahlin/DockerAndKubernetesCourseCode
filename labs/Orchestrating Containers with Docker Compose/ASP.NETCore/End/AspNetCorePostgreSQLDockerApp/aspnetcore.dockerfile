FROM microsoft/dotnet:sdk

LABEL author="Dan Wahlin"

ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /var/www/aspnetcoreapp

COPY . .

EXPOSE 5000

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore && dotnet run"]

# Note that this is only for demo and is intended to keep things simple. 
# A multi-stage dockerfile would normally be used here to build the .dll and use
# the microsoft/dotnet:aspnetcore-runtime image for the final image