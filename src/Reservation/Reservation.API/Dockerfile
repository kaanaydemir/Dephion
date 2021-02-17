#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY src/Reservation/Reservation.API/Reservation.API.csproj src/Reservation/Reservation.API/
COPY src/Reservation/Rezervation.Core/Reservation.Core.csproj src/Reservation/Rezervation.Core/
COPY src/Reservation/Reservation.Infrastructure/Reservation.Infrastructure.csproj src/Reservation/Reservation.Infrastructure/
COPY src/Reservation/Reservation.Application/Reservation.Application.csproj src/Reservation/Reservation.Application/
RUN dotnet restore "src/Reservation/Reservation.API/Reservation.API.csproj"
COPY . .
WORKDIR "/src/src/Reservation/Reservation.API"
RUN dotnet build "Reservation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reservation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation.API.dll"]
