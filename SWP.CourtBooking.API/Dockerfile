FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SWP.CourtBooking.API/SWP.CourtBooking.API.csproj","SWP.CourtBooking.API/"] 
COPY ["SWP.CourtBooking.Repository/SWP.CourtBooking.Repository.csproj","SWP.CourtBooking.Repository/"] 
RUN dotnet restore "SWP.CourtBooking.API/SWP.CourtBooking.API.csproj"
COPY . .
WORKDIR /src/SWP.CourtBooking.API
RUN dotnet build "SWP.CourtBooking.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SWP.CourtBooking.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","SWP.CourtBooking.API.dll"]