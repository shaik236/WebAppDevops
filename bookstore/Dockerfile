#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["bookstore/bookstore.csproj", "bookstore/"]
RUN dotnet restore "bookstore/bookstore.csproj"
COPY . .
WORKDIR "/src/bookstore"
RUN dotnet build "bookstore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bookstore.csproj" -c Release -o /app/publish

FROM base AS final
RUN groupadd -r appuser && useradd -r -g appuser appuser
RUN chown appuser: /app
WORKDIR /app
COPY --from=publish /app/publish .

USER appuser


ENTRYPOINT ["dotnet", "bookstore.dll"]