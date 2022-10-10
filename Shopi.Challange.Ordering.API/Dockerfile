#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shopi.Challange.Ordering.API/Shopi.Challange.Ordering.API.csproj", "Shopi.Challange.Ordering.API/"]
COPY ["Shopi.Challange.Ordering.Business/Shopi.Challange.Ordering.Business.csproj", "Shopi.Challange.Ordering.Business/"]
COPY ["Shopi.Challange.Ordering.Data/Shopi.Challange.Ordering.Data.csproj", "Shopi.Challange.Ordering.Data/"]
COPY ["Shopi.Challange.Ordering.Core/Shopi.Challange.Ordering.Core.csproj", "Shopi.Challange.Ordering.Core/"]
RUN dotnet restore "Shopi.Challange.Ordering.API/Shopi.Challange.Ordering.API.csproj"
COPY . .
WORKDIR "/src/Shopi.Challange.Ordering.API"
RUN dotnet build "Shopi.Challange.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopi.Challange.Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopi.Challange.Ordering.API.dll"]