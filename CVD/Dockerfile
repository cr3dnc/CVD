FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CVD/CVD.csproj", "CVD/"]
RUN dotnet restore "CVD/CVD.csproj"
COPY . .
WORKDIR "/src/CVD"
RUN dotnet build "CVD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CVD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CVD.dll"]
