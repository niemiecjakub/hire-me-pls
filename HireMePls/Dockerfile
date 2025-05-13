# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["HireMePls.csproj", "./"]
RUN dotnet restore "HireMePls.csproj"

COPY . .
RUN dotnet build "HireMePls.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "HireMePls.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HireMePls.dll"]
