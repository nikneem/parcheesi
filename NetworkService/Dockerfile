FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64916
EXPOSE 44338

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NetworkService/NetworkService.csproj NetworkService/
RUN dotnet restore NetworkService/NetworkService.csproj
COPY . .
WORKDIR /src/NetworkService
RUN dotnet build NetworkService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NetworkService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetworkService.dll"]
