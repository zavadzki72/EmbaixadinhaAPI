#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Embaixadinha.API/Embaixadinha.API.csproj", "Embaixadinha.API/"]
RUN dotnet restore "Embaixadinha.API/Embaixadinha.API.csproj"
COPY . .
WORKDIR "/src/Embaixadinha.API"
RUN dotnet build "Embaixadinha.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Embaixadinha.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Embaixadinha.API.dll"]