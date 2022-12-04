FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["scorTest/scorTest.csproj", "scorTest/"]
RUN dotnet restore "scorTest/scorTest.csproj"
COPY . .
WORKDIR "/src/scorTest"
RUN dotnet build "scorTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "scorTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "scorTest.dll"]
