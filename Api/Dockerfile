#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestDockerBD/TestDockerBD.csproj", "TestDockerBD/"]
RUN dotnet restore "TestDockerBD/TestDockerBD.csproj"
COPY . .
WORKDIR "/src/TestDockerBD"
RUN dotnet build "TestDockerBD.csproj" -c Release -o /app/build
RUN dotnet ef migrations bundle

FROM build AS publish
RUN dotnet publish "TestDockerBD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDockerBD.dll"]