FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["de4aber.cAppsule.Socket/de4aber.cAppsule.Socket.csproj", "de4aber.cAppsule.Socket/"]
RUN dotnet restore "de4aber.cAppsule.Socket/de4aber.cAppsule.Socket.csproj"
COPY . .
WORKDIR "/src/de4aber.cAppsule.Socket"
RUN dotnet build "de4aber.cAppsule.Socket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "de4aber.cAppsule.Socket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "de4aber.cAppsule.Socket.dll"]
