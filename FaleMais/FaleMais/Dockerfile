#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FaleMais/fale-mais-back.csproj", "FaleMais/"]
RUN dotnet restore "FaleMais/fale-mais-back.csproj"
COPY . .
WORKDIR "/src/FaleMais"
RUN dotnet build "fale-mais-back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fale-mais-back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fale-mais-back.dll"]