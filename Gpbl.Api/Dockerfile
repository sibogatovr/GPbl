FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Gpbl.sln", "./"]
COPY ["Gpbl.Api/Gpbl.Api.csproj", "Gpbl.Api/"]
COPY ["Gpbl.Application/Gpbl.Application.csproj", "Gpbl.Application/"]
COPY ["Gpbl.Domain/Gpbl.Domain.csproj", "Gpbl.Domain/"]
COPY ["Gpbl.Infrastructure/Gpbl.Infrastructure.csproj", "Gpbl.Infrastructure/"]

RUN dotnet restore "Gpbl.Api/Gpbl.Api.csproj"

COPY . .
WORKDIR "/src/Gpbl.Api"
RUN dotnet build "Gpbl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Gpbl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gpbl.Api.dll"]
