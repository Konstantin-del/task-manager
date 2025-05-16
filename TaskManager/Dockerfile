FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ./TaskManager.Presentation/*.csproj ./TaskManager.Presentation/
RUN dotnet restore TaskManager.Presentation/TaskManager.Presentation.csproj

COPY ./TaskManager.Presentation/. ./TaskManager.Presentation/
RUN dotnet publish TaskManager.Presentation/TaskManager.Presentation.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "TaskManager.Presentation.dll"]

