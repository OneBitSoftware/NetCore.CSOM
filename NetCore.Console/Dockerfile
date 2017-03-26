FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT ["dotnet", "NetCore.Console.dll"]
ARG source=.
WORKDIR /app
COPY $source .
