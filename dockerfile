FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY cAppsule/bin/Debug/net6.0/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "WebApplication.dll"]