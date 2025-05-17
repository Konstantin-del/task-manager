FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore TaskManager.Presentation/TaskManager.Presentation.csproj

COPY . .

RUN dotnet publish TaskManager.Presentation/TaskManager.Presentation.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "TaskManager.Presentation.dll"]



