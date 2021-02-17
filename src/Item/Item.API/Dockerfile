#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY src/Item/Item.API/Item.API.csproj src/Item/Item.API/
RUN dotnet restore "src/Item/Item.API/Item.API.csproj"
COPY . .
WORKDIR "/src/src/Item/Item.API"
RUN dotnet build "Item.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Item.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Item.API.dll"]
