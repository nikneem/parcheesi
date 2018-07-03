FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 7902
EXPOSE 44391

FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-stretch-slim AS build
WORKDIR /src
COPY IdentityService/IdentityService.csproj IdentityService/
RUN dotnet restore IdentityService/IdentityService.csproj
COPY . .
WORKDIR /src/IdentityService
RUN dotnet build IdentityService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish IdentityService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IdentityService.dll"]
