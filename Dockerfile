FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/CleanArchitecture.API/CleanArchitecture.API.csproj", "Presentation/CleanArchitecture.API/"]
COPY ["Core/CleanArchitecture.Application/CleanArchitecture.Application.csproj", "Core/CleanArchitecture.Application/"]
COPY ["Core/CleanArchitecture.Domain/CleanArchitecture.Domain.csproj", "Core/CleanArchitecture.Domain/"]
COPY ["Infrastructure/CleanArchitecture.Persistence/CleanArchitecture.Persistence.csproj", "Infrastructure/CleanArchitecture.Persistence/"]
COPY ["Infrastructure/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj", "Infrastructure/CleanArchitecture.Infrastructure/"]
RUN dotnet restore "Presentation/CleanArchitecture.API/CleanArchitecture.API.csproj"
COPY . .
WORKDIR "/src/Presentation/CleanArchitecture.API"
RUN dotnet build "CleanArchitecture.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CleanArchitecture.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.API.dll"]
