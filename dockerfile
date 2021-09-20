FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

RUN dotnet nuget add source https://api.nuget.org/v3/index.json
RUN dotnet nuget add source https://baget.basjanssen.eu/ -n MyPrivateRepo

# copy csproj and restore as distinct layers
COPY *.sln .
COPY EuroJudoWebContestSheets/*.csproj ./EuroJudoWebContestSheets/
COPY EJUPublisher/*.csproj ./EJUPublisher/
RUN dotnet restore

# copy everything else and build app
COPY EuroJudoWebContestSheets/. ./EuroJudoWebContestSheets/
WORKDIR /app/EuroJudoWebContestSheets
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/EuroJudoWebContestSheets/out ./
ENTRYPOINT ["dotnet", "EuroJudoWebContestSheets.dll"]
