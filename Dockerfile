FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Restore solution
COPY ./CloudTrader.Weather.sln ./
COPY ./src/CloudTrader.Weather.Api/CloudTrader.Weather.Api.csproj  ./src/CloudTrader.Weather.Api/CloudTrader.Weather.Api.csproj

RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "CloudTrader.Weather.Api.dll"]
