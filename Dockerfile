FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY de4aber.cAppsule.WebAPI/bin/Debug/net6.0/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "de4aber.cAppsule.WebAPI.dll"]
