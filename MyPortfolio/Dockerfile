# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyPortfolio/MyPortfolio.csproj", "./"]
RUN dotnet restore "./MyPortfolio.csproj"
COPY . .
RUN dotnet build "MyPortfolio.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "MyPortfolio.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyPortfolio.dll"]
