ARG NUGET_USR
ARG NUGET_PW

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Move the credentials to a jenkins credential and inject them using docker arguments

RUN dotnet nuget add source https://baget.basjanssen.eu/v3/index.json -n MyPrivateRepo -u ${NUGET_USR} -p ${NUGET_PW} --store-password-in-clear-text

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
