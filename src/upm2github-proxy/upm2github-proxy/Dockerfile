#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["upm2github-proxy/upm2github-proxy.csproj", "upm2github-proxy/"]
RUN dotnet restore "upm2github-proxy/upm2github-proxy.csproj"
COPY . .
WORKDIR "/src/upm2github-proxy"
RUN dotnet build "upm2github-proxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "upm2github-proxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "upm2github-proxy.dll"]