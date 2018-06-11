FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52201
EXPOSE 44351

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Clients/PwaSpaClient/PwaSpaClient.csproj Clients/PwaSpaClient/
RUN dotnet restore Clients/PwaSpaClient/PwaSpaClient.csproj
COPY . .
WORKDIR /src/Clients/PwaSpaClient
RUN dotnet build PwaSpaClient.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PwaSpaClient.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PwaSpaClient.dll"]
