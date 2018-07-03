FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 64918
EXPOSE 44341

FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-stretch-slim AS build
WORKDIR /src
COPY GameService/GameService.csproj GameService/
RUN dotnet restore GameService/GameService.csproj
COPY . .
WORKDIR /src/GameService
RUN dotnet build GameService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GameService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GameService.dll"]
