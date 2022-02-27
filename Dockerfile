FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ARG NUGET_USR
ARG NUGET_PW
WORKDIR /app

# Install typescript tools

RUN npm i typescript webpack @microsoft/signalr @types/node @types/react @types/react-dom

# Add private repository using credentials from Jenkins

RUN dotnet nuget add source https://baget.basjanssen.eu/v3/index.json -n MyPrivateRepo -u $NUGET_USR -p $NUGET_PW --store-password-in-clear-text

# copy csproj and restore as distinct layers
COPY *.sln .
COPY EuroJudoWebContestSheets/*.csproj ./EuroJudoWebContestSheets/
COPY EJUPublisher/*.csproj ./EJUPublisher/
COPY EuroJudoWebContestSheets.Tests/*.csproj ./EuroJudoWebContestSheets.Tests/
RUN dotnet restore

# copy everything else and build app
COPY EuroJudoWebContestSheets/. ./EuroJudoWebContestSheets/
WORKDIR /app/EuroJudoWebContestSheets

# Compile typescript
RUN tsc

# Run Webpack
RUN npm run wbp

#Compile C#
RUN dotnet publish -c Release -o out

# Build the new image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/EuroJudoWebContestSheets/out .
ENTRYPOINT ["dotnet", "EuroJudoWebContestSheets.dll"]
EXPOSE 80
