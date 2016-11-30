FROM microsoft/dotnet:latest

WORKDIR /app

COPY global.json .
COPY nlog-es /app/nlog-es
COPY NLog.Targets.ElasticSearch /app/NLog.Targets.ElasticSearch

RUN ["dotnet", "restore"]

EXPOSE 5000/tcp

WORKDIR /app/nlog-es

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000"]