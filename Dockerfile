FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

WORKDIR /src
COPY /src /app
# Use native linux file polling for better performance
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app
ENTRYPOINT dotnet watch run --project=YourProject.WebClient/YourProject.WebClient.csproj -urls=http://+:5000
