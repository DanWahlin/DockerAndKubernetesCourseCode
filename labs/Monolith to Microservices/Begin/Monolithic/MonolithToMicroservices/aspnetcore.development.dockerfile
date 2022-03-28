FROM mcr.microsoft.com/dotnet/sdk:5.0

LABEL author="Dan Wahlin"

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

WORKDIR /var/www/aspnetcoreapp

CMD ["/bin/sh", "-c", "dotnet restore && dotnet run"]
