FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 12153
EXPOSE 44381

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY WebClient/WebClient.csproj WebClient/
RUN dotnet restore WebClient/WebClient.csproj
COPY . .
WORKDIR /src/WebClient
RUN dotnet build WebClient.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebClient.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebClient.dll"]
