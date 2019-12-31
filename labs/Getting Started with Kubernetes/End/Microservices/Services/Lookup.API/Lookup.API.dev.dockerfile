FROM mcr.microsoft.com/dotnet/core/sdk

LABEL author="Dan Wahlin"

ENV DOTNET_USE_POLLING_FILE_WATCHER=1

WORKDIR /var/www/app

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore && dotnet watch run"]
