FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64911
EXPOSE 44348

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY IdentityServer/IdentityServer.csproj IdentityServer/
RUN dotnet restore IdentityServer/IdentityServer.csproj
COPY . .
WORKDIR /src/IdentityServer
RUN dotnet build IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish IdentityServer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IdentityServer.dll"]
