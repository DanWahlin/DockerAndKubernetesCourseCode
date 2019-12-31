FROM mcr.microsoft.com/dotnet/core/sdk

LABEL author="Dan Wahlin"

ENV ASPNETCORE_URLS=http://+:5000

WORKDIR /var/www/aspnetcoreapp

COPY . .

EXPOSE 5000

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore && dotnet run"]

# Note that this is only for demo and is intended to keep things simple. 
# A multi-stage dockerfile would normally be used here to build the .dll and use
# the mcr.microsoft.com/dotnet/core/aspnet image for the final image