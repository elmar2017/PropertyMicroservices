#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Property/Property.API/Property.API.csproj", "Services/Property/Property.API/"]
RUN dotnet restore "Services/Property/Property.API/Property.API.csproj"
COPY . .
WORKDIR "/src/Services/Property/Property.API"
RUN dotnet build "Property.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Property.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Property.API.dll"]