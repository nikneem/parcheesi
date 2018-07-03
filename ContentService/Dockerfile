FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 64920
EXPOSE 44336

FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-stretch-slim AS build
WORKDIR /src
COPY ContentService/ContentService.csproj ContentService/
RUN dotnet restore ContentService/ContentService.csproj
COPY . .
WORKDIR /src/ContentService
RUN dotnet build ContentService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ContentService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContentService.dll"]
